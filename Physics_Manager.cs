using System.Xml.Serialization;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public enum traint
{
    Normal,
    FreezeX
}

public class Physics_Manager : MonoBehaviour
{
    public static Physics_Manager _myInstance;
    public static PhysicsDatabase_Data[] _dataSamples;
    public static DynamicsContainer _myContainer = new DynamicsContainer();
    public const string _phyFolderName = "phyData";
    public const string _dynCollectionName = "dynData";
    public const string _filName = "Assets/Resources/data/phyData/data.xml";
    public const string _rootFolderName = "Assets/Resources/data";
    const int dataLength = 1;
    public List<GameObject> _rigidCollection = new List<GameObject>();
    public delegate void RigidInstanceEventHandler(RigidPainter _rigid);
    public event RigidInstanceEventHandler onRigidChange;
    [SerializeField]
    GameObject _rigidIndicatorImage;
    PhysicsDataContainer container = new PhysicsDataContainer();
    RigidPainter _rigidPainterInstance;
    UIPhysic _indicatorManger;

    
private void Start()
    {

        _myInstance = this.GetComponent<Physics_Manager>();
        _dataSamples = new PhysicsDatabase_Data[dataLength];
        _indicatorManger = new UIPhysic(_rigidIndicatorImage);
        //  _indicatorManger
       // saveMaterialDatabase(); test material save tokens
        loadMaterialDatabase();
        //load xml
        //
    }


public void listen(GameObject _currentPointer)
    {
        var _speaker = new RigidPainter(_currentPointer.transform,_rigidCollection);
        if(_rigidPainterInstance!=null)
            _rigidPainterInstance.onListChange -= _indicatorManger.loadIndicators;

        _rigidPainterInstance = _speaker;
        _rigidPainterInstance.onListChange += _indicatorManger.loadIndicators;
    }

public void fillUpRigidCollection(GameObject _obj)
{
    
}

public void SavePhysics()
    {
        //foreach datamanager available
        if (_rigidCollection.Count < 1) return;
        //  AssetDatabase.Refresh();

        var _fileName = string.Format("{0}/{1}/{2}.xml", _rootFolderName, _phyFolderName, _dynCollectionName);
        if (!File.Exists(_fileName))
            StaticSaveData_Editor.createXML<DynamicsContainer>(_fileName, _myContainer);
        if (_rigidCollection.Count > 0)
            StaticSaveData_Editor.Save(_fileName, _myContainer, _myContainer.actors);
        else
            return;

    }
void loadMaterialDatabase()
    {
        var _dataContainer = StaticSaveData_Editor.Load<PhysicsDataContainer, PhysicsDatabase_Data>(_filName, container.data);
        var _actors = _dataContainer.data;
        for (int _x = 0; _x < _actors.Count; _x++)
        {
            _dataSamples[_x] = _actors[_x];
        }
    }

void saveMaterialDatabase()
    {
        PhysicsToken _sample = new PhysicsToken(container);// data
        Utilities.CreateFolder(_rootFolderName, _phyFolderName);
        StaticSaveData_Editor.createXML<PhysicsDataContainer>(_filName, container);
        StaticSaveData_Editor.Save(_filName, container,container.data);
        _sample.Disable();
    }

}



//xml specifics
[XmlRoot("DynamicCollection")]
public class DynamicsContainer
{
    [XmlArray("DynamicObjects")]
    [XmlArrayItem("Object")]
    public List<Dynamic_Data> actors = new List<Dynamic_Data>();

}
public class Dynamic_Data
{
    [XmlAttribute("Name")]
    public string name;

    [XmlElement("Contstraints")]
    public traint _constraint;

}




