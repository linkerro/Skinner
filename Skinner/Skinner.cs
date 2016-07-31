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
            var expectation = new Expectation(actualValue, _currentDescription, _currentSpec);
            _currentSpec.expectations.Add(expectation);
            return expectation;
        }

        public void Run()
        {
            Specs();
            foreach (var description in _descriptions)
            {
                _currentDescription = description;

                DescriptionEventArguments eventArgs=new DescriptionEventArguments {Description = description.description};
                onDescription?.Invoke(this,eventArgs);
                foreach (var spec in description.specList)
                {
                    _currentSpec = spec;
                    spec.spec();
                }
            }
        }

        public event Action<object, DescriptionEventArguments> onDescription;
    }

    public class DescriptionEventArguments : EventArgs
    {
        public string Description { get; set; }
    }

    internal class Description
    {
        public string description { get; set; }
        public Action spec { get; set; }
        public List<Test> specList { get; set; }=new List<Test>();
    }

    internal class Test
    {
        public string description { get; set; }
        public Action spec { get; set; }
        public List<Expectation> expectations { get; set; }=new List<Expectation>();
    }
}
