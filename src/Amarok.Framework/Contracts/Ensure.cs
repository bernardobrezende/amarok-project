using System;
using System.Linq;

namespace Amarok.Framework.Contracts
{
    public class Ensure
    {        
        private bool actualAssertion = true;
        private bool expected = true;
        // TODO [Contracts]: Segregate into many interfaces
        private object value;
        private object[] values;

        private Ensure(bool condition)
        {
            this.actualAssertion = condition;
        }

        private Ensure(bool condition, bool expected)
            : this(condition)
        {
            this.expected = expected;
        }

        private Ensure(object value)
        {
            this.value = value;
        }

        private Ensure(object[] values)
        {
            this.values = values;
        }

        public static Ensure That(bool assertion)
        {
            return new Ensure(assertion);
        }

        // TODO [Contracts]: Segregate into many interfaces 
        public static Ensure That(object value)
        {
            return new Ensure(value);
        }
        
        public static Ensure That(object[] values)
        {
            return new Ensure(values);
        }

        public Ensure IsTrue()
        {            
            return new Ensure(this.actualAssertion, true);
        }

        public Ensure IsFalse()
        {            
            return new Ensure(this.actualAssertion, false);
        }

        public Ensure Otherwise
        {
            get { return this; }
        }

        public void Throw<T>(string message = default(string))
            where T : Exception
        {
            var exception = (T)Activator.CreateInstance(typeof(T), new[] { message });
            if (this.actualAssertion != this.expected)
                throw exception;
        }        

        public Ensure IsNotNull()
        {
            return new Ensure(this.value != null);
        }

        public Ensure HasValue()
        {
            return new Ensure(!String.IsNullOrEmpty(Convert.ToString(this.value)));
        }

        public Ensure AreAllNotNull()
        {
            return new Ensure(values != null && values.All(x => x != null));
        }
    }
}