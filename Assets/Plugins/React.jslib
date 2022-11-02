// Файл: MyPlugin.jslib

mergeInto(LibraryManager.library, 
{
  Info_Player: function (user_info) 
  {
    window.dispatchReactUnityEvent("Info_Player",Pointer_stringify(user_info));
    
  },
  Attributes_Player: function (user_info) 
  {
    window.dispatchReactUnityEvent("Attributes_Player",Pointer_stringify(user_info));
    
  },
   Inventory_Player: function (user_info) 
  {
    window.dispatchReactUnityEvent("Inventory_Player",Pointer_stringify(user_info));
    
  },
  Text_Message: function (str) 
  {
    window.alert(UTF8ToString(str));
  },
  Text_Message_Attributes: function (str) 
  {
    window.alert(UTF8ToString(str));
  },
});