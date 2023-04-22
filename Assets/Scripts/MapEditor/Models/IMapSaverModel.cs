using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public interface IMapSaverModel
{
   public List<Dropdown.OptionData> GetAllSaveFilesForView();

   public void LoadSave(Dropdown.OptionData data);
}