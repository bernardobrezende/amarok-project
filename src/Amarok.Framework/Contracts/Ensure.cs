using System;

namespace Amarok.Framework.Contracts
{
    public class Ensure
    {        
        private bool actualAssertion = true;
        private bool expected = true;

        private Ensure(bool condition)
        {
            this.actualAssertion = condition;
        }

        private Ensure(bool condition, bool mustBe)
            : this(condition)
        {
            this.expected = mustBe;
        }

        public static Ensure That(bool assertion)
        {
            return new Ensure(assertion);
        }

        public Ensure IsTrue()
        {            
            return new Ensure(this.actualAssertion, true);
        }

        public Ensure IsFalse()
        {            
            return new Ensure(this.actualAssertion, false);
        }

        public Ensure Otherwise()
        {
            return new Ensure(this.actualAssertion, this.expected);
        }

        public void Throw<T>(string message = default(string))
            where T : Exception
        {
            var exception = (T)Activator.CreateInstance(typeof(T), new[] { message });
            if (this.actualAssertion != this.expected)
                throw exception;
        }
    }
}