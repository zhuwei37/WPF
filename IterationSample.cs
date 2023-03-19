using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace WpfApp1
{
   

    public class IterationSample : IEnumerable
    {
        object[] values;
        int startingpoint;

        public IterationSample(object[] values, int startingpoint)
        {
            this.values = values;
            this.startingpoint = startingpoint;
        }
        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < values.Length; index++)
            {
                yield return values[(index + startingpoint) % values.Length];
            }
        }
        public class IterationSampleIterator : IEnumerator
        {
            IterationSample parent;
            int position;

            internal IterationSampleIterator(IterationSample parent)
            {
                this.parent = parent;
                position = -1;
            }
            public object Current
            {
                get 
                {
                    if (position == -1||position==parent.values.Length)
                    {
                        throw new InvalidOperationException();
                    }
                    int index = position + parent.startingpoint;
                    index = index % parent.values.Length;
                    return parent.values[index];
                }
            }

            public bool MoveNext()
            {
                if (position != parent.values.Length)
                {
                    position++;

                }
                return position < parent.values.Length;
            }

            public void Reset()
            {
                position = -1;
            }
        }

    }
    
}
