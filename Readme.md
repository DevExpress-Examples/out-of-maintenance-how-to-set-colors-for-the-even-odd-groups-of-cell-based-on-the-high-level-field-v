<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128579703/10.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2399)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsApplication53/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication53/Form1.vb))
* [Program.cs](./CS/WindowsApplication53/Program.cs) (VB: [Program.vb](./VB/WindowsApplication53/Program.vb))
<!-- default file list end -->
# How to set colors for the Even/Odd groups of cell based on the high level Field Values


<p>This example shows how to apply different appearances to the Even and Odd groups of cells. A appearance customization is applied according to the "Year" field values. To accomplish this task it is necessary to create an enumerator that contains all unique Field Values of the "Year" field in its visible order. Please refer to the <strong>CreateFieldValueEnumerator</strong> method that performs this task. The enumerator should be updated every time when the pivot grid layout is changed. You can handle the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraPivotGridPivotGridControl_GridLayouttopic">PivotGridControl.GridLayout </a> to accomplish this task. Finally color customizations are applied via the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraPivotGridPivotGridControl_CustomAppearancetopic">PivotGridControl.CustomAppearance</a> event.</p>

<br/>


