using System;

namespace Skinner
{
    public class Expectation
    {
        private object _actualValue;
        private Description _description;
        private Test _spec;
        private bool _hasBeenMet;

        public bool HasBeenMet => _hasBeenMet;

        internal Expectation(object actualValue, Description description, Test spec)
        {
            _actualValue = actualValue;
            _description = description;
            _spec = spec;
        }

        public void toBe(object expectedValue)
        {
            _hasBeenMet = _actualValue.Equals(expectedValue);

            if (!_hasBeenMet)
            {
                var errorMessage = $"{_description.description} {Environment.NewLine} {_spec.description} {Environment.NewLine} Expected `{_actualValue}` to be `{expectedValue}.`";
                throw new Exception(errorMessage);
            }
        }
    }
}