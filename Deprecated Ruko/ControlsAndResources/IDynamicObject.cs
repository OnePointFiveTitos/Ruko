using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ControlsAndResources
{
    ////Basic implementation
    ////Use this for the static members of class that you want to be a dynamic object
    ////This implementation basically tells the whatever is using the dynamic object what properties you want to be displayed
    
    //public static Dictionary<string, string> Mapping { get; }
    //static NameViewModel()
    //{
    //    //create a sample object, this will be used by hte 'nameof' operator below, allowing for easy refactoring later on
    //    NameViewModel sample = new NameViewModel(null, null); //ignore the NameViewModel, it can be anything that implemented IDynamicObject
    //    Mapping = new Dictionary<string, string>()
    //    {
    //        //using 'nameof' for the key allows for easy refactoring; set the value to whatever you want- for me, I want the value to be displayed in a label
    //        [nameof(sample.First)] = "First: ",
    //        [nameof(sample.Middle)] = "Middle: ",
    //        [nameof(sample.Last)] = "Last: ",
    //    };
    //}

    ////Reference the static Mapping in the instance with this
    //    public Dictionary<string, string> PropertiesMapping => Mapping;
    

    /// <summary>
    /// Enables an object to be used with a DynamicControl which reflects over the object and returns a list of properties based off a predicate that then populates the DynamicControl with a Control per property
    /// </summary>
    public interface IDynamicObject
    {
        Dictionary<string,string> PropertiesMapping { get; }
        void PopulateControl(DynamicControl control);
    }
}