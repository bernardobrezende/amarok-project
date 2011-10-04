using System;
using System.Diagnostics;
using System.Reflection;

namespace Amarok.Framework.Contracts
{
    public class Ensure
    {
        private static Predicate<bool> currentPredicate = null;
        
        private Ensure(Predicate<bool> currentPred)
        {
            currentPredicate = currentPred;
        }

        private Ensure()
        {
            currentPredicate = new Predicate<bool>(x => x);
        }

        public static Ensure That(Predicate<bool> func)
        {
            return new Ensure(func);
        }

        public void IsTrue()
        {
            bool assertion = currentPredicate.Invoke(true);

            if (!assertion)
                // TODO [Exceptions]: Define error type and message
                throw new Exception("");
        }

        public void IsFalse()
        {
            bool assertion = currentPredicate.Invoke(false);

            if (assertion)
                // TODO [Exceptions]: Define error type and message
                throw new Exception("");
        }
    }
}