﻿using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCf_Explorer_Sol.Manager;
using PCf_Explorer_Sol.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using XrmToolBox.Extensibility;

namespace PCf_Explorer_Sol
{
	public partial class MyPluginControl : PluginControlBase
	{
		private Settings mySettings;
		Dictionary<int, string> dic = new Dictionary<int, string>();
		Dictionary<string, string> dicControls = new Dictionary<string, string>();

		public MyPluginControl()
		{
			InitializeComponent();
		}

		private void MyPluginControl_Load(object sender, EventArgs e)
		{
			//ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

			// Loads or creates the settings for the plugin
			if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
			{
				mySettings = new Settings();
				listViewPCF.SetDoubleBuffered(true);
				listViewDetails.SetDoubleBuffered(true);
				LogWarning("Settings not found => a new settings file has been created!");
			}
			else
			{
				LogInfo("Settings found and loaded");
			}
			LoadCrmComponentsTypes();
			LoadPCFContorl();
		}

		void LoadCrmComponentsTypes()
		{
			dic.Add(1, "Entity");
			dic.Add(2, "Attribute");
			dic.Add(3, "Relationship");
			dic.Add(4, "Attribute Picklist Value");
			dic.Add(5, "Attribute Lookup Value");
			dic.Add(6, "View Attribute");
			dic.Add(7, "Localized Label");
			dic.Add(8, "Relationship Extra Condition");
			dic.Add(9, "Option Set");
			dic.Add(10, "Entity Relationship");
			dic.Add(11, "Entity Relationship Role");
			dic.Add(12, "Entity Relationship Relationships");
			dic.Add(13, "Managed Property");
			dic.Add(14, "Entity Key");
			dic.Add(16, "Privilege");
			dic.Add(17, "PrivilegeObjectTypeCode");
			dic.Add(20, "Role");
			dic.Add(21, "Role Privilege");
			dic.Add(22, "Display String");
			dic.Add(23, "Display String Map");
			dic.Add(24, "Form");
			dic.Add(25, "Organization");
			dic.Add(26, "Saved Query");
			dic.Add(29, "Workflow");
			dic.Add(31, "Report");
			dic.Add(32, "Report Entity");
			dic.Add(33, "Report Category");
			dic.Add(34, "Report Visibility");
			dic.Add(35, "Attachment");
			dic.Add(36, "Email Template");
			dic.Add(37, "Contract Template");
			dic.Add(38, "KB Article Template");
			dic.Add(39, "Mail Merge Template");
			dic.Add(44, "Duplicate Rule");
			dic.Add(45, "Duplicate Rule Condition");
			dic.Add(46, "Entity Map");
			dic.Add(47, "Attribute Map");
			dic.Add(48, "Ribbon Command");
			dic.Add(49, "Ribbon Context Group");
			dic.Add(50, "Ribbon Customization");
			dic.Add(52, "Ribbon Rule");
			dic.Add(53, "Ribbon Tab To Command Map");
			dic.Add(55, "Ribbon Diff");
			dic.Add(59, "Saved Query Visualization");
			dic.Add(60, "System Form");
			dic.Add(61, "Web Resource");
			dic.Add(62, "Site Map");
			dic.Add(63, "Connection Role");
			dic.Add(64, "Complex Control");
			dic.Add(70, "Field Security Profile");
			dic.Add(71, "Field Permission");
			dic.Add(90, "Plugin Type");
			dic.Add(91, "Plugin Assembly");
			dic.Add(92, "SDK Message Processing Step");
			dic.Add(93, "SDK Message Processing Step Image");
			dic.Add(95, "Service Endpoint");
			dic.Add(150, "Routing Rule");
			dic.Add(151, "Routing Rule Item");
			dic.Add(152, "SLA");
			dic.Add(153, "SLA Item");
			dic.Add(154, "Convert Rule");
			dic.Add(155, "Convert Rule Item");
			dic.Add(65, "Hierarchy Rule");
			dic.Add(161, "Mobile Offline Profile");
			dic.Add(162, "Mobile Offline Profile Item");
			dic.Add(165, "Similarity Rule");
			dic.Add(66, "Custom Control");
			dic.Add(68, "Custom Control Default Config");
			dic.Add(166, "Data Source Mapping");
			dic.Add(201, "SDKMessage");
			dic.Add(202, "SDKMessageFilter");
			dic.Add(203, "SdkMessagePair");
			dic.Add(204, "SdkMessageRequest");
			dic.Add(205, "SdkMessageRequestField");
			dic.Add(206, "SdkMessageResponse");
			dic.Add(207, "SdkMessageResponseField");
			dic.Add(210, "WebWizard");
			dic.Add(18, "Index");
			dic.Add(208, "Import Map");
			dic.Add(300, "Canvas App");
			dic.Add(371, "Connector");
			dic.Add(372, "Connector");
			dic.Add(380, "Environment Variable Definition");
			dic.Add(381, "Environment Variable Value");
			dic.Add(400, "AI Project Type");
			dic.Add(401, "AI Project");
			dic.Add(402, "AI Configuration");
			dic.Add(430, "Entity Analytics Configuration");
			dic.Add(431, "Attribute Image Configuration");
			dic.Add(432, "Entity Image Configuration");


		}
		private void tsbClose_Click(object sender, EventArgs e)
		{
			CloseTool();
		}

		private void tsbSample_Click(object sender, EventArgs e)
		{
			// The ExecuteMethod method handles connecting to an
			// organization if XrmToolBox is not yet connected
			//ExecuteMethod(GetAccounts);
		}



		/// <summary>
		/// This event occurs when the plugin is closed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
		{
			// Before leaving, save the settings
			SettingsManager.Instance.Save(GetType(), mySettings);
		}

		/// <summary>
		/// This event occurs when the connection has been updated in XrmToolBox
		/// </summary>
		public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
		{
			base.UpdateConnection(newService, detail, actionName, parameter);

			if (mySettings != null && detail != null)
			{
				mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
				LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
			}
		}

		#region My Implementations

		private void LoadPCFContorl()
		{
			WorkAsync(new WorkAsyncInfo
			{
				Message = "Loading PCF Controls (Field/Dataset)",
				Work = (worker, args) =>
				{
					PCFManager pCFManager = new PCFManager(ConnectionDetail.ServiceClient);

					args.Result = pCFManager.GetPCfControls();

				},
				PostWorkCallBack = (args) =>
				{
					if (args.Error != null)
					{
						MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					var result = args.Result as List<PCFModel>;
					if (result != null && result.Count > 0)
					{
						result = result.OrderByDescending(P => P.createdon).ToList();
						LoadflowList(result);

						//MessageBox.Show($"Found {result.Entities.Count} accounts");
					}
				}
			});

		}

		private void LoadflowList(List<PCFModel> pcfControls)
		{

			listViewPCF.Items.Clear();
			listViewPCF.MultiSelect = false;
			ListViewItem item = null;
			ListViewItem.ListViewSubItem subitem;
			ListViewItem.ListViewSubItem subsubitem;


			var groupTrg = new ListViewGroup($"PCF Controls: {pcfControls.Count}");
			lbltotal.Text = $"Total PCF Controls: {pcfControls.Count}";
			listViewPCF.Groups.Add(groupTrg);
			// Initialize the tile size.
			listViewPCF.TileSize = new Size(560, 62);
			ImageList myImageList = new ImageList();
			myImageList.ColorDepth = ColorDepth.Depth32Bit;
			myImageList.Images.Add(
			  LoadImage("https://raw.githubusercontent.com/yesadahmed/PCF-Explorer/main/pcf80.png"));
			myImageList.ImageSize = new Size(55, 55);
			listViewPCF.LargeImageList = myImageList;
			listViewPCF.View = View.Tile;

			listViewPCF.Columns.AddRange(new ColumnHeader[]
			  {new ColumnHeader(), new ColumnHeader(), new ColumnHeader()});

			dicControls = new Dictionary<string, string>();
			foreach (var pcf in pcfControls)
			{
				item = new ListViewItem(new string[] { pcf.ClientJson.DisplayName }, 0, groupTrg);
				item.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Regular);
				item.UseItemStyleForSubItems = false;
				subitem = new ListViewItem.ListViewSubItem();
				subitem.Text = pcf.name;
				subitem.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
				subitem.ForeColor = Color.Black;
				item.SubItems.Add(subitem);

				subsubitem = new ListViewItem.ListViewSubItem();
				subsubitem = new ListViewItem.ListViewSubItem();
				subsubitem.Text = pcf.compatibledatatypes;
				subsubitem.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
				subsubitem.ForeColor = Color.FromArgb(54, 69, 79);
				item.SubItems.Add(subsubitem);

				item.Tag = pcf.ClientJson;//as cache

				listViewPCF.Items.Add(item);
				dicControls.Add(pcf.ClientJson.CustomControlId, pcf.clientjsonraw);

			}
			//RenderPieChart(pcfControls);
			//RenderCustomDefaultControls(pcfControls);

			//comboBoxcustom.Tag = pcfControls;
			comboBoxtotal.Tag = pcfControls;
			comboBoxtotal.SelectedIndex = 0;
			//comboBoxcustom.SelectedIndex = 0;

		}
		Image LoadImage(string url)
		{
			System.Net.WebRequest request =
				System.Net.WebRequest.Create(url);

			System.Net.WebResponse response = request.GetResponse();
			System.IO.Stream responseStream =
				response.GetResponseStream();

			Bitmap bmp = new Bitmap(responseStream);

			responseStream.Dispose();

			return bmp;
		}

		//void RenderPieChart(List<PCFModel> pcfControls)
		//{

		//	var fDatasetCount = pcfControls.Count(p => p.IsFieldtype.Equals(false));
		//	var filedsCount = pcfControls.Count(p => p.IsFieldtype.Equals(true));

		//	DataTable dt = new DataTable("PCFControls");
		//	//dt.Clear();
		//	dt.Columns.Add("Type");
		//	dt.Columns.Add("Count");
		//	DataRow _newRow = dt.NewRow();
		//	_newRow["Type"] = "Field";
		//	_newRow["Count"] = filedsCount;
		//	dt.Rows.Add(_newRow);
		//	_newRow = dt.NewRow();
		//	_newRow["Type"] = "Dataset";
		//	_newRow["Count"] = fDatasetCount;
		//	dt.Rows.Add(_newRow);


		//	chartpie.Series[0].ChartType = SeriesChartType.Pie;
		//	chartpie.DataSource = dt;
		//	chartpie.Series[0].XValueMember = "Type";
		//	chartpie.Series[0].YValueMembers = "Count";
		//	chartpie.Titles.Add($"Total PCF Controls: {pcfControls.Count}");

		//	chartpie.Series[0].IsValueShownAsLabel = true;
		//	chartpie.ChartAreas[0].Area3DStyle.Enable3D = true;
		//	chartpie.BackColor = Color.Transparent;
		//	chartpie.ChartAreas[0].BackColor = Color.Transparent;
		//	chartpie.Legends[0].BackColor = Color.Transparent;

		//}

		//void RenderCustomDefaultControls(List<PCFModel> pcfControls)
		//{
		//	var mscontrol = pcfControls.Count(p => p.DefaultMSControl.Equals(true));
		//	var customcontrol = pcfControls.Count(p => p.DefaultMSControl.Equals(false));

		//	DataTable dt = new DataTable("PCFControls");
		//	//dt.Clear();
		//	dt.Columns.Add("Type");
		//	dt.Columns.Add("Count");
		//	DataRow _newRow = dt.NewRow();
		//	_newRow["Type"] = "Microsoft";
		//	_newRow["Count"] = mscontrol;
		//	dt.Rows.Add(_newRow);
		//	_newRow = dt.NewRow();
		//	_newRow["Type"] = "Custom";
		//	_newRow["Count"] = customcontrol;
		//	dt.Rows.Add(_newRow);

		//	chart1.Series[0].ChartType = SeriesChartType.Pie;
		//	chart1.DataSource = dt;
		//	chart1.Series[0].XValueMember = "Type";
		//	chart1.Series[0].YValueMembers = "Count";
		//	chart1.Titles.Add($"Microsoft vs Custom Controls: {pcfControls.Count}");

		//	chart1.Series[0].IsValueShownAsLabel = true;
		//	chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
		//	chart1.BackColor = Color.Transparent;
		//	chart1.ChartAreas[0].BackColor = Color.Transparent;
		//	chart1.Legends[0].BackColor = Color.Transparent;

		//	Series S = chart1.Series[0];
		//	for (int idx = 0; idx < dt.Columns.Count; idx++)
		//	{
		//		DataPoint dp = new DataPoint();
		//		dp.ToolTip = "adnan" + idx;
		//		chart1.Series[0].Points.Add(dp);
		//	}

		//}
		#endregion

		private void btnsearch_Click(object sender, EventArgs e)
		{

		}

		private void txtsearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				ListViewItem foundItem =
	   listViewPCF.FindItemWithText(txtsearch.Text, true, 0, true);
				if (foundItem != null)
				{
					listViewPCF.Items[foundItem.Index].Selected = true;
					listViewPCF.Select();
					foundItem.EnsureVisible();

				}
				e.Handled = true;
			}
		}

		private void comboBoxtotal_SelectedIndexChanged(object sender, EventArgs e)
		{
			IEnumerable<PCFModel> items = null;
			if (comboBoxtotal.SelectedItem == null) return;
			var lst = comboBoxtotal.Tag as List<PCFModel>;
			if (lst != null && lst.Count > 0)
			{
				listBox1.Items.Clear();
				var selection = Convert.ToString(comboBoxtotal.SelectedItem);
				if (selection == "Field")
				{
					items = lst.Where(p => p.compatibledatatypes != "Grid");
					if (items.Any())
						lbltotal.Text = $"Total Field controls: {items.ToList().Count}";
				}
				else if (selection == "Dataset")
				{
					items = lst.Where(p => p.compatibledatatypes.Equals("Grid"));
					if (items.Any())
						lbltotal.Text = $"Total Dataset controls: {items.ToList().Count}";
				}
				else if (selection == "Custom controls")
				{
					items = lst.Where(p => p.DefaultMSControl.Equals(false));
					if (items.Any())
						lbltotal.Text = $"Total Custom controls: {items.ToList().Count}";
				}
				else if (selection == "Default controls")
				{
					items = lst.Where(p => p.DefaultMSControl.Equals(true));
					if (items.Any())
						lbltotal.Text = $"Total Default(microsoft) controls: {items.ToList().Count}";
				}
				if (items.Any())
				{
					foreach (var item in items)
					{
						listBox1.Items.Add(item.ClientJson.DisplayName);
					}
				}

			}
		}

		//private void comboBoxcustom_SelectedIndexChanged(object sender, EventArgs e)
		//{

		//	IEnumerable<PCFModel> items = null;
		//	if (comboBoxcustom.SelectedItem == null) return;
		//	var lst = comboBoxcustom.Tag as List<PCFModel>;
		//	if (lst != null && lst.Count > 0)
		//	{
		//		listBox2.Items.Clear();
		//		var selection = Convert.ToString(comboBoxcustom.SelectedItem);
		//		if (selection == "Custom")
		//		{
		//			items = lst.Where(p => p.DefaultMSControl.Equals(false));
		//		}
		//		else
		//		{
		//			items = lst.Where(p => p.DefaultMSControl.Equals(true));
		//		}
		//		if (items.Any())
		//		{
		//			foreach (var item in items)
		//			{
		//				listBox2.Items.Add(item.ClientJson.DisplayName);
		//			}
		//		}
		//	}
		//}

		private void listViewPCF_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListView.SelectedListViewItemCollection items = this.listViewPCF.SelectedItems;
			if (items.Count <= 0) return;
			LoadDependentPCFControl(items);


		}


		void LoadDependentPCFControl(ListView.SelectedListViewItemCollection items)
		{
			ListGroupDisplyModel lstGroupForms = null;//mkae PCF hosted forms/Dashboard group
			ListViewItem itemNew = null;


			listViewDetails.Clear();
			PCFClientJsonModel client = null;
			RetrieveDependentComponentsRequest request = null;
			//https://github.com/yesadahmed/PCF-Explorer/blob/main/orginal.png?raw=true
			ImageList myImageList = new ImageList();
			myImageList.ColorDepth = ColorDepth.Depth32Bit;
			myImageList.Images.Add(
			  LoadImage("https://raw.githubusercontent.com/yesadahmed/PCF-Explorer/main/form_transparent.png"));//0 Form

			myImageList.Images.Add(
			  LoadImage("https://raw.githubusercontent.com/yesadahmed/PCF-Explorer/main/gear-64.png"));//1 solution


			myImageList.Images.Add(
			  LoadImage("https://raw.githubusercontent.com/yesadahmed/PCF-Explorer/main/Hand-80.png"));//2 properties
			myImageList.ImageSize = new Size(47, 47);

			myImageList.Images.Add(
			  LoadImage("https://raw.githubusercontent.com/yesadahmed/PCF-Explorer/main/dataset.png"));//3 dataset
			myImageList.ImageSize = new Size(47, 47);

			myImageList.Images.Add(
			  LoadImage("https://raw.githubusercontent.com/yesadahmed/PCF-Explorer/main/file.png"));//4 resources
			myImageList.ImageSize = new Size(47, 47);




			listViewDetails.LargeImageList = myImageList;
			listViewDetails.View = View.Tile;

			listViewDetails.TileSize = new Size(560, 54);
			listViewDetails.Columns.AddRange(new ColumnHeader[]
		  {new ColumnHeader(), new ColumnHeader(), new ColumnHeader()});

			string pcfjson = string.Empty;
			foreach (ListViewItem item in items)
			{
				client = item.Tag as PCFClientJsonModel;
				pcfjson = item.Name;
				request =
				  new RetrieveDependentComponentsRequest
				  {
					  ObjectId = new Guid(client.CustomControlId),
					  ComponentType = 66 //custom control
				  };
			}

			try
			{
				var response =
					(RetrieveDependentComponentsResponse)ConnectionDetail.ServiceClient.Execute(
					request);

				if (response != null && response.EntityCollection != null)
				{
					lstGroupForms = new ListGroupDisplyModel();
					lstGroupForms.Forms = new List<CRMFormModel>();
					foreach (var ent in response.EntityCollection.Entities)
					{
						var depType = ent.GetAttributeValue<OptionSetValue>("dependentcomponenttype");
						var depCompId = ent.GetAttributeValue<Guid>("dependentcomponentobjectid");

						var groupName = dic[depType.Value];
						switch (depType.Value)
						{
							case 60:
								if (string.IsNullOrWhiteSpace(lstGroupForms.GroupName))
									lstGroupForms.GroupName = dic[depType.Value];

								var formProp = GetformProperties(depCompId);
								if (formProp != null)
								{
									lstGroupForms.Forms.Add(formProp);
								}
								break;

						}

					}

					if (lstGroupForms != null) //Display Forms Group
					{
						var grp = new ListViewGroup(lstGroupForms.GroupName);
						listViewDetails.Groups.Add(grp);


						foreach (var litem in lstGroupForms.Forms)
						{
							itemNew = new ListViewItem(new string[] { litem.Name, litem.entity, litem.FormType }, 0, grp);

							listViewDetails.Items.Add(itemNew);
						}

						var grpsol = new ListViewGroup("Solution");
						listViewDetails.Groups.Add(grpsol);
						listViewDetails.Items.Add(new ListViewItem(new string[] { client.SolutionName, "IsManaged: " + client.ismanaged, "Version: " + client.version }, 1, grpsol));
					}


					//display properties and later Solution
					if (client.Properties != null)
					{

						if (client.Properties.Properties != null)
						{
							var grpprop = new ListViewGroup("Properties");
							listViewDetails.Groups.Add(grpprop);
							foreach (var prop in client.Properties.Properties)
							{
								var _type = prop.TypeGroup != null ? prop.TypeGroup : prop.Type;
								listViewDetails.Items.Add(new ListViewItem(new string[] { prop.Name, _type, "Required: " + prop.Required }, 2, grpprop));

							}
						}



						if (client.Properties.DataSets != null)
						{
							string columns = string.Empty;
							var grpdataset = new ListViewGroup("DataSet");
							listViewDetails.Groups.Add(grpdataset);
							foreach (var prop in client.Properties.DataSets)
							{
								var _type = prop.TypeGroup != null ? prop.TypeGroup : prop.Type;
								if (prop.Columns != null && prop.Columns.Count > 0)
								{
									string delimiter = ",";
									columns = string.Join(delimiter, prop.Columns.Select(c => c.Name).ToList());

								}

								listViewDetails.Items.Add(new ListViewItem(new string[] { prop.Name, _type, "Columns: " + columns }, 3, grpdataset));

							}
						}

						if (client.Properties.Resources != null)
						{
							string columns = string.Empty;
							var grpdataset = new ListViewGroup("Resources");
							listViewDetails.Groups.Add(grpdataset);
							foreach (var prop in client.Properties.Resources)
							{
								var _type = prop.TypeGroup != null ? prop.TypeGroup : prop.Type;

								listViewDetails.Items.Add(new ListViewItem(new string[] { prop.Name, "Type: " + _type, "Loadorder: " + prop.LoadOrder }, 4, grpdataset));

							}
						}

					}
				}

				if (dicControls.ContainsKey(client.CustomControlId))
				{
					string jsonFormatted = JValue.Parse(dicControls[client.CustomControlId]).ToString(Formatting.Indented);

					string pattern = @"(?<=\"")(.*?)(?=\"":)";//json property identifier
															  // Create a Regex  
					Regex rg = new Regex(pattern);


					txtpcfjson.Text = jsonFormatted;

					foreach (Match match in rg.Matches(txtpcfjson.Text))
					{
						txtpcfjson.Select(match.Index, match.Length);
						txtpcfjson.SelectionColor = Color.Blue;
					}
				}
				//string jsonFormatted = JValue.Parse(pcfjson).ToString(Formatting.Indented);
				//txtpcfjson.Text = jsonFormatted;
			}
			catch (Exception ex)
			{


			}

		}

		CRMFormModel GetformProperties(Guid FormId)
		{
			CRMFormModel cRMFormModel = null;

			var form = ConnectionDetail.ServiceClient.Retrieve("systemform", FormId, new ColumnSet("name", "objecttypecode", "type"));

			if (form != null)
			{
				cRMFormModel = new CRMFormModel();
				cRMFormModel.FormId = FormId;
				cRMFormModel.entity = "Entity: " + form.GetAttributeValue<string>("objecttypecode");
				cRMFormModel.Name = "FormName: " + form.GetAttributeValue<string>("name");
				var _formType = form.GetAttributeValue<OptionSetValue>("type");
				if (_formType != null)
					cRMFormModel.FormType = "Type: " + GetCRMFormType(_formType.Value);
			}
			return cRMFormModel;
		}

		string GetCRMFormType(int formType)
		{
			string type = "";

			switch (formType)
			{
				case 0:
					type = "Dashboard";
					break;

				case 1:
					type = "AppointmentBook";
					break;

				case 2:
					type = "Main";
					break;

				case 3:
					type = "MiniCampaignBO";
					break;

				case 4:
					type = "Preview";
					break;

				case 5:
					type = "Mobile - Express";
					break;

				case 6:
					type = "Quick View Form";
					break;
				case 7:
					type = "Quick Create";
					break;
				case 8:
					type = "Dialog";
					break;
				case 9:
					type = "Task Flow Form";
					break;
				case 10:
					type = "InteractionCentricDashboard";
					break;
				case 11:
					type = "Card";
					break;
				case 12:
					type = "Main - Interactive experience";
					break;
				case 13:
					type = "Contextual Dashboard";
					break;
				case 100:
					type = "Other";
					break;
				case 101:
					type = "MainBackup";
					break;
				case 102:
					type = "AppointmentBookBackup";
					break;
				case 103:
					type = "Power BI Dashboard";
					break;


			}

			return type;
		}

		private void txtsearch_TextChanged(object sender, EventArgs e)
		{

		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (listBox1.SelectedItem != null)
				{
					string curItem = listBox1.SelectedItem.ToString();
					ListViewItem foundItem = listViewPCF.FindItemWithText(curItem, true, 0, true);
					if (foundItem != null)
					{
						listViewPCF.Items[foundItem.Index].Selected = true;
						listViewPCF.Select();
						foundItem.EnsureVisible();

					}
				}

			}
			catch (Exception)
			{


			}
		}
	}
}