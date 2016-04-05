
namespace _03_GenericList
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class |
                    AttributeTargets.Enum | AttributeTargets.Interface |
                    AttributeTargets.Method)]
    public class VersionAttribute : Attribute
    {
        private int minor;
        private int major;

        public VersionAttribute(int major, int minor)
        {
            this.Minor = minor;
            this.Major = major;
        }

        public int Major
        {
            get { return this.major; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Major version cannot be negative.");
                }

                this.major = value;
            }
        }

        public int Minor
        {
            get { return this.minor; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Minor version cannot be negative.");
                }

                this.minor = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Version: ({0}.{1})", this.Major, this.Minor);
        }
    }
}
