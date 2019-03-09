namespace Ruko
{
    public class SystemModel
    {
        internal string boilerMake;
        internal string primaryType;
        internal string secondaryType;
        internal string burnerMake;
        internal string burnerSize;
        internal string nozzleSize;
        internal string filterSize;
        internal string transformerType;
        internal string circulatorType;

        public SystemModel(string boilerMake, string primaryType, string secondaryType, string burnerMake, string burnerSize, string nozzleSize, string filterSize, string transformerSize, string circulatorSize)
        {
            this.boilerMake = boilerMake;
            this.primaryType = primaryType;
            this.secondaryType = secondaryType;
            this.burnerMake = burnerMake;
            this.burnerSize = burnerSize;
            this.nozzleSize = nozzleSize;
            this.filterSize = filterSize;
            this.transformerType = transformerSize;
            this.circulatorType = circulatorSize;
        }

        public SystemModel()
        {

        }
    }
}