using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinner
{
    public abstract class Spec
    {
        public abstract void Specs();

        List<Description> _descriptions = new List<Description>();
        private Description _currentDescription;
        private Test _currentSpec;

        protected void describe(string descriptionName, Action spec)
        {
            var description = new Description { description = descriptionName, spec = spec, specList = new List<Test>()};
            _currentDescription = description;

            description.spec();
            _descriptions.Add(description);
        }

        protected void it(string specDescription, Action spec)
        {
            _currentDescription.specList.Add(new Test { description = specDescription, spec = spec });
        }

        protected Expectation expect(object actualValue)
        {
            return new Expectation(actualValue, _currentDescription, _currentSpec);
        }

        public void Run()
        {
            Specs();
            foreach (var description in _descriptions)
            {
                foreach (var spec in description.specList)
                {
                    _currentSpec = spec;
                    spec.spec();
                }
            }
        }
    }

    internal class Description
    {
        public string description { get; set; }
        public Action spec { get; set; }
        public List<Test> specList { get; set; }
    }

    internal class Test
    {
        public string description { get; set; }
        public Action spec { get; set; }
    }

    public class Expectation
    {
        private object _actualValue;
        private Description _description;
        private Test _spec;

        internal Expectation(object actualValue, Description description, Test spec)
        {
            _actualValue = actualValue;
            _description = description;
            _spec = spec;
        }

        public void toBe(object expectedValue)
        {
            if (_actualValue != expectedValue)
            {
                var errorMessage = $"{_description.description} {Environment.NewLine} {_spec.description} {Environment.NewLine} Expected `{_actualValue}` to be `{expectedValue}.`";
                throw new Exception(errorMessage);
            }
        }
    }
}
