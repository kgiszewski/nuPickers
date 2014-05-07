﻿namespace nuComponents.DataTypes.PropertyEditors.XmlDropDownPicker
{
    using ClientDependency.Core;
    using Umbraco.Core.PropertyEditors;
    using Umbraco.Web.PropertyEditors;

    // EDITOR UI
    [PropertyEditor("xmlDropDownPicker", "nuComponents: Xml DropDown Picker", "App_Plugins/nuComponents/DataTypes/Shared/DropDownPicker/DropDownPickerEditor.html", ValueType = "TEXT")]
    [PropertyEditorAsset(ClientDependencyType.Javascript, "App_Plugins/nuComponents/DataTypes/Shared/DropDownPicker/DropDownPickerEditorController.js")]

    // RESOURCES
    [PropertyEditorAsset(ClientDependencyType.Javascript, "App_Plugins/nuComponents/DataTypes/Shared/Picker/PickerResource.js")]

    // CONFIG
    [PropertyEditorAsset(ClientDependencyType.Javascript, "App_Plugins/nuComponents/DataTypes/Shared/XmlDataSource/XmlDataSourceConfigController.js")]
    public class XmlDropDownPickerPropertyEditor : PropertyEditor
    {
        protected override PreValueEditor CreatePreValueEditor()
        {
            return new XmlDropDownPickerPreValueEditor();
        }
    }
}
