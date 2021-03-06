﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iterator.Abstract;

namespace Iterator.Concrete
{
    class ConcreteIterator : Iterator.Abstract.Iterator
    {
        private readonly Aggregate _aggregate;
        private int _current = 0;

        public ConcreteIterator(Aggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        public override object First()
        {
            return _aggregate[0];
        }

        public override object Next()
        {
            object ret = null;

            _current++;

            if (_current < _aggregate.Count)
            {
                ret = _aggregate[_current];
            }

            return ret;
        }

        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }
}
