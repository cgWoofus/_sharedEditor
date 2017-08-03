
using UnityEngine;

public class PhysicsToken 
{
    PhysicsDatabase_Data _sample = new PhysicsDatabase_Data();
    PhysicsDataContainer _mycontainer;
    string name;
    // Use this for initialization
    public PhysicsToken(PhysicsDataContainer _container)
    {
        _mycontainer = _container;
        Enable();
    }

    public void StoreTextureData()
    {
        // sample data set
        _sample.name = "Wood";
        _sample._mass = 10f;
        _sample._lDrag = 0f;
        _sample._ADrag = 0.05f;
        _sample._gScale = 1f;
        _sample._matId = 0;
    }
    void addData()
    {
        StaticSaveData_Editor.AddActorData<PhysicsDatabase_Data>(_mycontainer.data, _sample);
    }

    void Enable()
    {
        StaticSaveData_Editor.BeforeSaveProcess += StoreTextureData;
        StaticSaveData_Editor.BeforeSaveProcess += addData;
    }
    public void Disable()
    {
        StaticSaveData_Editor.BeforeSaveProcess -= StoreTextureData;
        StaticSaveData_Editor.BeforeSaveProcess -= addData;
    }
    public void LoadData()
    {
        // status = data.status;
    }

}