using System;
using System.Collections.Generic;
using System.Text;

namespace Core.svelto.ui
{
    public abstract class SveltoValue
    {

        /// <summary>
        /// context May be null
        /// </summary>
        /// <param name="context">Context.</param>
        abstract public float get(SveltoElement context);

        /// <summary>
        /// A value that is always zero.
        /// </summary>
        static public Fixed zero = new Fixed(0);


        /// <summary>
        /// A fixed value that is not computed each time it is used.
        /// </summary>
        public class Fixed : SveltoValue
        {
            float value;

            public Fixed(float value)
            {
                this.value = value;
            }

            public override float get(SveltoElement context)
            {
                return value;
            }
        }


        static public SveltoValue minWidth = new MinWidthValue();

        /// <summary>
        /// SveltoValue that is the minWidth of the element in the cell.
        /// </summary>
        public class MinWidthValue : SveltoValue
        {
            public override float get(SveltoElement context)
            {
                if (context is ISveltoLayout)
                    return ((ISveltoLayout) context).minWidth;
                return context == null ? 0 : context.width;
            }
        }


        static public SveltoValue minHeight = new MinHeightValue();

        /// <summary>
        /// SveltoValue that is the minHeight of the element in the cell.
        /// </summary>
        public class MinHeightValue : SveltoValue
        {
            public override float get(SveltoElement context)
            {
                if (context is ISveltoLayout)
                    return ((ISveltoLayout) context).minHeight;
                return context == null ? 0 : context.height;
            }
        }


        static public SveltoValue prefWidth = new PrefWidthValue();

        /// <summary>
        /// SveltoValue that is the prefWidth of the element in the cell.
        /// </summary>
        public class PrefWidthValue : SveltoValue
        {
            public override float get(SveltoElement context)
            {
                if (context is ISveltoLayout)
                    return ((ISveltoLayout) context).preferredWidth;
                return context == null ? 0 : context.width;

            }
        }


        static public SveltoValue prefHeight = new PrefHeightValue();

        /// <summary>
        /// SveltoValue that is the prefHeight of the element in the cell.
        /// </summary>
        public class PrefHeightValue : SveltoValue
        {
            public override float get(SveltoElement context)
            {
                if (context is ISveltoLayout)
                    return ((ISveltoLayout) context).preferredHeight;
                return context == null ? 0 : context.height;
            }
        }


        static public SveltoValue maxWidth = new MaxWidthValue();

        /// <summary>
        /// SveltoValue that is the maxWidth of the element in the cell.
        /// </summary>
        public class MaxWidthValue : SveltoValue
        {
            public override float get(SveltoElement context)
            {
                if (context is ISveltoLayout)
                    return ((ISveltoLayout) context).maxWidth;
                return context == null ? 0 : context.width;
            }
        }


        static public SveltoValue maxHeight = new MaxHeightValue();

        /// <summary>
        /// SveltoValue that is the maxHeight of the element in the cell.
        /// </summary>
        public class MaxHeightValue : SveltoValue
        {
            public override float get(SveltoElement context)
            {
                if (context is ISveltoLayout)
                    return ((ISveltoLayout) context).maxHeight;
                return context == null ? 0 : context.height;
            }
        }


        /// <summary>
        /// SveltoValue that is the maxHeight of the element in the cell.
        /// </summary>
        static public SveltoValue percentWidth(float percent)
        {
            return new PercentWidthValue()
            {
                percent = percent
            };
        }

        /// <summary>
        /// Returns a value that is a percentage of the element's width.
        /// </summary>
        public class PercentWidthValue : SveltoValue
        {
            public float percent;

            public override float get(SveltoElement element)
            {
                return element.width * percent;
            }
        }


        /// <summary>
        /// Returns a value that is a percentage of the specified elements's width. The context element is ignored.
        /// </summary>
        static public SveltoValue percentWidth(float percent, SveltoElement delegateElement)
        {
            return new PercentWidthDelegateValue()
            {
                delegateElement = delegateElement,
                percent = percent
            };
        }

        /// <summary>
        /// Returns a value that is a percentage of the specified elements's width. The context element is ignored.
        /// </summary>
        public class PercentWidthDelegateValue : SveltoValue
        {
            public SveltoElement delegateElement;
            public float percent;

            public override float get(SveltoElement element)
            {
                return delegateElement.width * percent;
            }
        }


        /// <summary>
        /// Returns a value that is a percentage of the element's height.
        /// </summary>
        static public SveltoValue percentHeight(float percent)
        {
            return new PercentageHeightValue()
            {
                percent = percent
            };
        }

        /// <summary>
        /// Returns a value that is a percentage of the element's height.
        /// </summary>
        public class PercentageHeightValue : SveltoValue
        {
            public float percent;

            public override float get(SveltoElement element)
            {
                return element.height * percent;
            }
        }


        /// <summary>
        /// Returns a value that is a percentage of the specified elements's height. The context element is ignored.
        /// </summary>
        static public SveltoValue percentHeight(float percent, SveltoElement delegateElement)
        {
            return new PercentHeightDelegateValue()
            {
                delegateElement = delegateElement,
                percent = percent
            };
        }

        /// <summary>
        /// Returns a value that is a percentage of the specified elements's height. The context element is ignored.
        /// </summary>
        public class PercentHeightDelegateValue : SveltoValue
        {
            public SveltoElement delegateElement;
            public float percent;

            public override float get(SveltoElement element)
            {
                return delegateElement.height * percent;
            }
        }

    }

}
