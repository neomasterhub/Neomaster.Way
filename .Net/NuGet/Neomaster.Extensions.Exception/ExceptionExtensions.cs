using System;
using System.Collections.Generic;
using System.Linq;
using E = System.Exception;

namespace Neomaster.Extensions.Exception
{
    public static class ExceptionExtensions
    {
        public static List<E> GetAllInnerExceptions(this E e, bool addAggregate = false, bool aggregateToSingle = false)
        {
            List<E> list = new List<E>();

            if (e == null)
            {
                return list;
            }

            if (e is AggregateException ae)
            {
                if (addAggregate)
                {
                    list.Add(aggregateToSingle ? new E(ae.Message) : ae);
                }

                list.AddRange(ae.InnerExceptions.SelectMany(ie => ie.GetAllInnerExceptions(addAggregate, aggregateToSingle)));
            }
            else
            {
                list.Add(e);
                list.AddRange(e.InnerException.GetAllInnerExceptions(addAggregate, aggregateToSingle));
            }

            return list;
        }
    }
}
