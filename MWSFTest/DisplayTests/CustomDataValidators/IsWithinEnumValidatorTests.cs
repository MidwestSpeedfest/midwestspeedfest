using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MudBlazor;
using MWSFBlazorFrontEnd.Helpers.CustomDataValidators;
using NUnit.Framework;

namespace MWSFTest.DisplayTests.CustomDataValidators
{
    public class IsWithinEnumValidatorTests
    {
        private Type _enumType;
        private IsWithinEnumValidator _sut;
        private int _minValid;
        private int _maxValid;
        private List<int> _validVals;

        [SetUp]
        public void Setup()
        {
            _validVals = new();

            _enumType = typeof(Severity);
            var vals = Enum.GetValues(_enumType);
            foreach (var val in vals)
            {
                _validVals.Add((int)val);
            }

            _minValid = _validVals.Min();
            _maxValid = _validVals.Max();
            
            _sut = new IsWithinEnumValidator()
            {
                EnumToCheck = _enumType
            };
        }

        [Test]
        public void PassWhenInsideRange()
        {
            Assert.That(_sut.IsValid(_maxValid), Is.True, $"Value {_maxValid} is not valid for this Enum");
            Assert.That(_sut.IsValid(_minValid), Is.True, $"Value {_minValid} is not valid for this Enum");
        }

        [Test]
        public void FailWhenOutOfMaxRange()
        {
            Assert.That(_sut.IsValid(_maxValid+1), Is.False, $"Value {_maxValid + 1} is over minimum range for this Enum");
            Assert.That(_sut.IsValid(_minValid-1), Is.False, $"Value {_minValid - 1} is under minimum range for this Enum");
        }
    }
}
