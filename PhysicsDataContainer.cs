using System.Xml.Serialization;
using System.Collections.Generic;
public class PhysicsDataContainer
{
    [XmlArray("Physics_Database")]
    [XmlArrayItem("Physics_Data")]
    public List<PhysicsDatabase_Data> data = new List<PhysicsDatabase_Data>();
}
public class PhysicsDatabase_Data
{
    [XmlAttribute("Name")]
    public string name;

    [XmlElement("Material_ID")]
    public int _matId;

    [XmlElement("Mass")]
    public float _mass;

    [XmlElement("Linear_Drag")]
    public float _lDrag;

    [XmlElement("Angular_Drag")]
    public float _ADrag;

    [XmlElement("Gravity_Scale")]
    public float _gScale;

}

public class PhysicsObjectsCollection
{
    
    [XmlAttribute("Name")]
    public string _objectname;


  //  [XmlAttribute("Constraints")]
    //public string _objectname;


}

