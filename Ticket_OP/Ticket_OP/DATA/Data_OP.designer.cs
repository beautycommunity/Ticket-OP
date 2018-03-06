﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ticket_OP.DATA
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="OPTicket")]
	public partial class Data_OPDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertMAS_WH(MAS_WH instance);
    partial void UpdateMAS_WH(MAS_WH instance);
    partial void DeleteMAS_WH(MAS_WH instance);
    partial void InsertMAS_AREA(MAS_AREA instance);
    partial void UpdateMAS_AREA(MAS_AREA instance);
    partial void DeleteMAS_AREA(MAS_AREA instance);
    partial void InsertTRN_TICKET(TRN_TICKET instance);
    partial void UpdateTRN_TICKET(TRN_TICKET instance);
    partial void DeleteTRN_TICKET(TRN_TICKET instance);
    partial void InsertTRN_TICKET_I(TRN_TICKET_I instance);
    partial void UpdateTRN_TICKET_I(TRN_TICKET_I instance);
    partial void DeleteTRN_TICKET_I(TRN_TICKET_I instance);
    partial void InsertTRN_TICKET_F(TRN_TICKET_F instance);
    partial void UpdateTRN_TICKET_F(TRN_TICKET_F instance);
    partial void DeleteTRN_TICKET_F(TRN_TICKET_F instance);
    partial void InsertDEV_TASK_FLAG(DEV_TASK_FLAG instance);
    partial void UpdateDEV_TASK_FLAG(DEV_TASK_FLAG instance);
    partial void DeleteDEV_TASK_FLAG(DEV_TASK_FLAG instance);
    #endregion
		
		public Data_OPDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["OPTicketConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public Data_OPDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Data_OPDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Data_OPDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Data_OPDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<MAS_WH> MAS_WHs
		{
			get
			{
				return this.GetTable<MAS_WH>();
			}
		}
		
		public System.Data.Linq.Table<MAS_AREA> MAS_AREAs
		{
			get
			{
				return this.GetTable<MAS_AREA>();
			}
		}
		
		public System.Data.Linq.Table<TRN_TICKET> TRN_TICKETs
		{
			get
			{
				return this.GetTable<TRN_TICKET>();
			}
		}
		
		public System.Data.Linq.Table<VW_TICKET> VW_TICKETs
		{
			get
			{
				return this.GetTable<VW_TICKET>();
			}
		}
		
		public System.Data.Linq.Table<TRN_TICKET_I> TRN_TICKET_Is
		{
			get
			{
				return this.GetTable<TRN_TICKET_I>();
			}
		}
		
		public System.Data.Linq.Table<TRN_TICKET_F> TRN_TICKET_Fs
		{
			get
			{
				return this.GetTable<TRN_TICKET_F>();
			}
		}
		
		public System.Data.Linq.Table<VW_TICKET_DETAIL> VW_TICKET_DETAILs
		{
			get
			{
				return this.GetTable<VW_TICKET_DETAIL>();
			}
		}
		
		public System.Data.Linq.Table<DEV_TASK_FLAG> DEV_TASK_FLAGs
		{
			get
			{
				return this.GetTable<DEV_TASK_FLAG>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MAS_WH")]
	public partial class MAS_WH : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _BRAND;
		
		private string _WHCODE;
		
		private string _WHNAME;
		
		private string _FULLNAME;
		
		private string _DBNAME;
		
		private string _ADDR_PROVINCE;
		
		private string _ADDR_TEL;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBRANDChanging(string value);
    partial void OnBRANDChanged();
    partial void OnWHCODEChanging(string value);
    partial void OnWHCODEChanged();
    partial void OnWHNAMEChanging(string value);
    partial void OnWHNAMEChanged();
    partial void OnFULLNAMEChanging(string value);
    partial void OnFULLNAMEChanged();
    partial void OnDBNAMEChanging(string value);
    partial void OnDBNAMEChanged();
    partial void OnADDR_PROVINCEChanging(string value);
    partial void OnADDR_PROVINCEChanged();
    partial void OnADDR_TELChanging(string value);
    partial void OnADDR_TELChanged();
    #endregion
		
		public MAS_WH()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BRAND", DbType="VarChar(5)")]
		public string BRAND
		{
			get
			{
				return this._BRAND;
			}
			set
			{
				if ((this._BRAND != value))
				{
					this.OnBRANDChanging(value);
					this.SendPropertyChanging();
					this._BRAND = value;
					this.SendPropertyChanged("BRAND");
					this.OnBRANDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WHCODE", DbType="VarChar(5) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string WHCODE
		{
			get
			{
				return this._WHCODE;
			}
			set
			{
				if ((this._WHCODE != value))
				{
					this.OnWHCODEChanging(value);
					this.SendPropertyChanging();
					this._WHCODE = value;
					this.SendPropertyChanged("WHCODE");
					this.OnWHCODEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WHNAME", DbType="VarChar(10)")]
		public string WHNAME
		{
			get
			{
				return this._WHNAME;
			}
			set
			{
				if ((this._WHNAME != value))
				{
					this.OnWHNAMEChanging(value);
					this.SendPropertyChanging();
					this._WHNAME = value;
					this.SendPropertyChanged("WHNAME");
					this.OnWHNAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FULLNAME", DbType="VarChar(50)")]
		public string FULLNAME
		{
			get
			{
				return this._FULLNAME;
			}
			set
			{
				if ((this._FULLNAME != value))
				{
					this.OnFULLNAMEChanging(value);
					this.SendPropertyChanging();
					this._FULLNAME = value;
					this.SendPropertyChanged("FULLNAME");
					this.OnFULLNAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DBNAME", DbType="VarChar(50)")]
		public string DBNAME
		{
			get
			{
				return this._DBNAME;
			}
			set
			{
				if ((this._DBNAME != value))
				{
					this.OnDBNAMEChanging(value);
					this.SendPropertyChanging();
					this._DBNAME = value;
					this.SendPropertyChanged("DBNAME");
					this.OnDBNAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADDR_PROVINCE", DbType="VarChar(20)")]
		public string ADDR_PROVINCE
		{
			get
			{
				return this._ADDR_PROVINCE;
			}
			set
			{
				if ((this._ADDR_PROVINCE != value))
				{
					this.OnADDR_PROVINCEChanging(value);
					this.SendPropertyChanging();
					this._ADDR_PROVINCE = value;
					this.SendPropertyChanged("ADDR_PROVINCE");
					this.OnADDR_PROVINCEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADDR_TEL", DbType="VarChar(20)")]
		public string ADDR_TEL
		{
			get
			{
				return this._ADDR_TEL;
			}
			set
			{
				if ((this._ADDR_TEL != value))
				{
					this.OnADDR_TELChanging(value);
					this.SendPropertyChanging();
					this._ADDR_TEL = value;
					this.SendPropertyChanged("ADDR_TEL");
					this.OnADDR_TELChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MAS_AREA")]
	public partial class MAS_AREA : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _WHCODE;
		
		private string _AREA;
		
		private string _BRAND;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnWHCODEChanging(string value);
    partial void OnWHCODEChanged();
    partial void OnAREAChanging(string value);
    partial void OnAREAChanged();
    partial void OnBRANDChanging(string value);
    partial void OnBRANDChanged();
    #endregion
		
		public MAS_AREA()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WHCODE", DbType="VarChar(5) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string WHCODE
		{
			get
			{
				return this._WHCODE;
			}
			set
			{
				if ((this._WHCODE != value))
				{
					this.OnWHCODEChanging(value);
					this.SendPropertyChanging();
					this._WHCODE = value;
					this.SendPropertyChanged("WHCODE");
					this.OnWHCODEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AREA", DbType="VarChar(20)")]
		public string AREA
		{
			get
			{
				return this._AREA;
			}
			set
			{
				if ((this._AREA != value))
				{
					this.OnAREAChanging(value);
					this.SendPropertyChanging();
					this._AREA = value;
					this.SendPropertyChanged("AREA");
					this.OnAREAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BRAND", DbType="VarChar(5)")]
		public string BRAND
		{
			get
			{
				return this._BRAND;
			}
			set
			{
				if ((this._BRAND != value))
				{
					this.OnBRANDChanging(value);
					this.SendPropertyChanging();
					this._BRAND = value;
					this.SendPropertyChanged("BRAND");
					this.OnBRANDChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TRN_TICKET")]
	public partial class TRN_TICKET : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _TK_ID;
		
		private string _TICKETNO;
		
		private string _WHCODE;
		
		private string _WHNAME;
		
		private string _AREA;
		
		private string _DETAIL;
		
		private string _STCODE;
		
		private System.Nullable<int> _SS_ID;
		
		private System.Nullable<System.DateTime> _CREATEDATE;
		
		private string _FLAG;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTK_IDChanging(int value);
    partial void OnTK_IDChanged();
    partial void OnTICKETNOChanging(string value);
    partial void OnTICKETNOChanged();
    partial void OnWHCODEChanging(string value);
    partial void OnWHCODEChanged();
    partial void OnWHNAMEChanging(string value);
    partial void OnWHNAMEChanged();
    partial void OnAREAChanging(string value);
    partial void OnAREAChanged();
    partial void OnDETAILChanging(string value);
    partial void OnDETAILChanged();
    partial void OnSTCODEChanging(string value);
    partial void OnSTCODEChanged();
    partial void OnSS_IDChanging(System.Nullable<int> value);
    partial void OnSS_IDChanged();
    partial void OnCREATEDATEChanging(System.Nullable<System.DateTime> value);
    partial void OnCREATEDATEChanged();
    partial void OnFLAGChanging(string value);
    partial void OnFLAGChanged();
    #endregion
		
		public TRN_TICKET()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TK_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int TK_ID
		{
			get
			{
				return this._TK_ID;
			}
			set
			{
				if ((this._TK_ID != value))
				{
					this.OnTK_IDChanging(value);
					this.SendPropertyChanging();
					this._TK_ID = value;
					this.SendPropertyChanged("TK_ID");
					this.OnTK_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TICKETNO", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string TICKETNO
		{
			get
			{
				return this._TICKETNO;
			}
			set
			{
				if ((this._TICKETNO != value))
				{
					this.OnTICKETNOChanging(value);
					this.SendPropertyChanging();
					this._TICKETNO = value;
					this.SendPropertyChanged("TICKETNO");
					this.OnTICKETNOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WHCODE", DbType="VarChar(10)")]
		public string WHCODE
		{
			get
			{
				return this._WHCODE;
			}
			set
			{
				if ((this._WHCODE != value))
				{
					this.OnWHCODEChanging(value);
					this.SendPropertyChanging();
					this._WHCODE = value;
					this.SendPropertyChanged("WHCODE");
					this.OnWHCODEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WHNAME", DbType="VarChar(10)")]
		public string WHNAME
		{
			get
			{
				return this._WHNAME;
			}
			set
			{
				if ((this._WHNAME != value))
				{
					this.OnWHNAMEChanging(value);
					this.SendPropertyChanging();
					this._WHNAME = value;
					this.SendPropertyChanged("WHNAME");
					this.OnWHNAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AREA", DbType="VarChar(20)")]
		public string AREA
		{
			get
			{
				return this._AREA;
			}
			set
			{
				if ((this._AREA != value))
				{
					this.OnAREAChanging(value);
					this.SendPropertyChanging();
					this._AREA = value;
					this.SendPropertyChanged("AREA");
					this.OnAREAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DETAIL", DbType="VarChar(500)")]
		public string DETAIL
		{
			get
			{
				return this._DETAIL;
			}
			set
			{
				if ((this._DETAIL != value))
				{
					this.OnDETAILChanging(value);
					this.SendPropertyChanging();
					this._DETAIL = value;
					this.SendPropertyChanged("DETAIL");
					this.OnDETAILChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STCODE", DbType="VarChar(5)")]
		public string STCODE
		{
			get
			{
				return this._STCODE;
			}
			set
			{
				if ((this._STCODE != value))
				{
					this.OnSTCODEChanging(value);
					this.SendPropertyChanging();
					this._STCODE = value;
					this.SendPropertyChanged("STCODE");
					this.OnSTCODEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SS_ID", DbType="Int")]
		public System.Nullable<int> SS_ID
		{
			get
			{
				return this._SS_ID;
			}
			set
			{
				if ((this._SS_ID != value))
				{
					this.OnSS_IDChanging(value);
					this.SendPropertyChanging();
					this._SS_ID = value;
					this.SendPropertyChanged("SS_ID");
					this.OnSS_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATEDATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> CREATEDATE
		{
			get
			{
				return this._CREATEDATE;
			}
			set
			{
				if ((this._CREATEDATE != value))
				{
					this.OnCREATEDATEChanging(value);
					this.SendPropertyChanging();
					this._CREATEDATE = value;
					this.SendPropertyChanged("CREATEDATE");
					this.OnCREATEDATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FLAG", DbType="VarChar(50)")]
		public string FLAG
		{
			get
			{
				return this._FLAG;
			}
			set
			{
				if ((this._FLAG != value))
				{
					this.OnFLAGChanging(value);
					this.SendPropertyChanging();
					this._FLAG = value;
					this.SendPropertyChanged("FLAG");
					this.OnFLAGChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_TICKET")]
	public partial class VW_TICKET
	{
		
		private int _TK_ID;
		
		private string _TICKETNO;
		
		private string _WHCODE;
		
		private string _WHNAME;
		
		private string _AREA;
		
		private string _DETAIL;
		
		private string _STCODE;
		
		private System.Nullable<System.DateTime> _CREATEDATE;
		
		private string _CREATETIME;
		
		private string _TNAME;
		
		private string _BRAND;
		
		private System.Nullable<int> _SS_ID;
		
		private string _FLAG;
		
		public VW_TICKET()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TK_ID", DbType="Int NOT NULL")]
		public int TK_ID
		{
			get
			{
				return this._TK_ID;
			}
			set
			{
				if ((this._TK_ID != value))
				{
					this._TK_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TICKETNO", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string TICKETNO
		{
			get
			{
				return this._TICKETNO;
			}
			set
			{
				if ((this._TICKETNO != value))
				{
					this._TICKETNO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WHCODE", DbType="VarChar(10)")]
		public string WHCODE
		{
			get
			{
				return this._WHCODE;
			}
			set
			{
				if ((this._WHCODE != value))
				{
					this._WHCODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WHNAME", DbType="VarChar(10)")]
		public string WHNAME
		{
			get
			{
				return this._WHNAME;
			}
			set
			{
				if ((this._WHNAME != value))
				{
					this._WHNAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AREA", DbType="VarChar(20)")]
		public string AREA
		{
			get
			{
				return this._AREA;
			}
			set
			{
				if ((this._AREA != value))
				{
					this._AREA = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DETAIL", DbType="VarChar(500)")]
		public string DETAIL
		{
			get
			{
				return this._DETAIL;
			}
			set
			{
				if ((this._DETAIL != value))
				{
					this._DETAIL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STCODE", DbType="VarChar(5)")]
		public string STCODE
		{
			get
			{
				return this._STCODE;
			}
			set
			{
				if ((this._STCODE != value))
				{
					this._STCODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATEDATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> CREATEDATE
		{
			get
			{
				return this._CREATEDATE;
			}
			set
			{
				if ((this._CREATEDATE != value))
				{
					this._CREATEDATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATETIME", DbType="VarChar(30)")]
		public string CREATETIME
		{
			get
			{
				return this._CREATETIME;
			}
			set
			{
				if ((this._CREATETIME != value))
				{
					this._CREATETIME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TNAME", DbType="NVarChar(50)")]
		public string TNAME
		{
			get
			{
				return this._TNAME;
			}
			set
			{
				if ((this._TNAME != value))
				{
					this._TNAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BRAND", DbType="VarChar(5)")]
		public string BRAND
		{
			get
			{
				return this._BRAND;
			}
			set
			{
				if ((this._BRAND != value))
				{
					this._BRAND = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SS_ID", DbType="Int")]
		public System.Nullable<int> SS_ID
		{
			get
			{
				return this._SS_ID;
			}
			set
			{
				if ((this._SS_ID != value))
				{
					this._SS_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FLAG", DbType="VarChar(50)")]
		public string FLAG
		{
			get
			{
				return this._FLAG;
			}
			set
			{
				if ((this._FLAG != value))
				{
					this._FLAG = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TRN_TICKET_I")]
	public partial class TRN_TICKET_I : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _TK_ID;
		
		private int _ORDERNO;
		
		private string _TK_MESAGE;
		
		private string _US_ID;
		
		private System.Nullable<System.DateTime> _CREATEDATE;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTK_IDChanging(int value);
    partial void OnTK_IDChanged();
    partial void OnORDERNOChanging(int value);
    partial void OnORDERNOChanged();
    partial void OnTK_MESAGEChanging(string value);
    partial void OnTK_MESAGEChanged();
    partial void OnUS_IDChanging(string value);
    partial void OnUS_IDChanged();
    partial void OnCREATEDATEChanging(System.Nullable<System.DateTime> value);
    partial void OnCREATEDATEChanged();
    #endregion
		
		public TRN_TICKET_I()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TK_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int TK_ID
		{
			get
			{
				return this._TK_ID;
			}
			set
			{
				if ((this._TK_ID != value))
				{
					this.OnTK_IDChanging(value);
					this.SendPropertyChanging();
					this._TK_ID = value;
					this.SendPropertyChanged("TK_ID");
					this.OnTK_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ORDERNO", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ORDERNO
		{
			get
			{
				return this._ORDERNO;
			}
			set
			{
				if ((this._ORDERNO != value))
				{
					this.OnORDERNOChanging(value);
					this.SendPropertyChanging();
					this._ORDERNO = value;
					this.SendPropertyChanged("ORDERNO");
					this.OnORDERNOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TK_MESAGE", DbType="VarChar(255)")]
		public string TK_MESAGE
		{
			get
			{
				return this._TK_MESAGE;
			}
			set
			{
				if ((this._TK_MESAGE != value))
				{
					this.OnTK_MESAGEChanging(value);
					this.SendPropertyChanging();
					this._TK_MESAGE = value;
					this.SendPropertyChanged("TK_MESAGE");
					this.OnTK_MESAGEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_US_ID", DbType="VarChar(5)")]
		public string US_ID
		{
			get
			{
				return this._US_ID;
			}
			set
			{
				if ((this._US_ID != value))
				{
					this.OnUS_IDChanging(value);
					this.SendPropertyChanging();
					this._US_ID = value;
					this.SendPropertyChanged("US_ID");
					this.OnUS_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATEDATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> CREATEDATE
		{
			get
			{
				return this._CREATEDATE;
			}
			set
			{
				if ((this._CREATEDATE != value))
				{
					this.OnCREATEDATEChanging(value);
					this.SendPropertyChanging();
					this._CREATEDATE = value;
					this.SendPropertyChanged("CREATEDATE");
					this.OnCREATEDATEChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TRN_TICKET_F")]
	public partial class TRN_TICKET_F : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _TK_ID;
		
		private short _ORDERNO;
		
		private int _FILENO;
		
		private string _PATH1;
		
		private string _PATH2;
		
		private string _PATH3;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTK_IDChanging(int value);
    partial void OnTK_IDChanged();
    partial void OnORDERNOChanging(short value);
    partial void OnORDERNOChanged();
    partial void OnFILENOChanging(int value);
    partial void OnFILENOChanged();
    partial void OnPATH1Changing(string value);
    partial void OnPATH1Changed();
    partial void OnPATH2Changing(string value);
    partial void OnPATH2Changed();
    partial void OnPATH3Changing(string value);
    partial void OnPATH3Changed();
    #endregion
		
		public TRN_TICKET_F()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TK_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int TK_ID
		{
			get
			{
				return this._TK_ID;
			}
			set
			{
				if ((this._TK_ID != value))
				{
					this.OnTK_IDChanging(value);
					this.SendPropertyChanging();
					this._TK_ID = value;
					this.SendPropertyChanged("TK_ID");
					this.OnTK_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ORDERNO", DbType="SmallInt NOT NULL", IsPrimaryKey=true)]
		public short ORDERNO
		{
			get
			{
				return this._ORDERNO;
			}
			set
			{
				if ((this._ORDERNO != value))
				{
					this.OnORDERNOChanging(value);
					this.SendPropertyChanging();
					this._ORDERNO = value;
					this.SendPropertyChanged("ORDERNO");
					this.OnORDERNOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FILENO", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int FILENO
		{
			get
			{
				return this._FILENO;
			}
			set
			{
				if ((this._FILENO != value))
				{
					this.OnFILENOChanging(value);
					this.SendPropertyChanging();
					this._FILENO = value;
					this.SendPropertyChanged("FILENO");
					this.OnFILENOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PATH1", DbType="VarChar(1000)")]
		public string PATH1
		{
			get
			{
				return this._PATH1;
			}
			set
			{
				if ((this._PATH1 != value))
				{
					this.OnPATH1Changing(value);
					this.SendPropertyChanging();
					this._PATH1 = value;
					this.SendPropertyChanged("PATH1");
					this.OnPATH1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PATH2", DbType="VarChar(1000)")]
		public string PATH2
		{
			get
			{
				return this._PATH2;
			}
			set
			{
				if ((this._PATH2 != value))
				{
					this.OnPATH2Changing(value);
					this.SendPropertyChanging();
					this._PATH2 = value;
					this.SendPropertyChanged("PATH2");
					this.OnPATH2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PATH3", DbType="VarChar(1000)")]
		public string PATH3
		{
			get
			{
				return this._PATH3;
			}
			set
			{
				if ((this._PATH3 != value))
				{
					this.OnPATH3Changing(value);
					this.SendPropertyChanging();
					this._PATH3 = value;
					this.SendPropertyChanged("PATH3");
					this.OnPATH3Changed();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_TICKET_DETAIL")]
	public partial class VW_TICKET_DETAIL
	{
		
		private int _TK_ID;
		
		private string _TICKETNO;
		
		private string _WHCODE;
		
		private string _WHNAME;
		
		private string _AREA;
		
		private string _DETAIL;
		
		private string _STCODE;
		
		private System.Nullable<System.DateTime> _CREATEDATE;
		
		private string _CREATETIME;
		
		private string _TNAME;
		
		private string _BRAND;
		
		private System.Nullable<int> _SS_ID;
		
		private string _FLAG;
		
		private int _ORDERNO;
		
		private string _TK_MESAGE;
		
		private string _US_ID;
		
		private System.Nullable<System.DateTime> _DETAILDATE;
		
		public VW_TICKET_DETAIL()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TK_ID", DbType="Int NOT NULL")]
		public int TK_ID
		{
			get
			{
				return this._TK_ID;
			}
			set
			{
				if ((this._TK_ID != value))
				{
					this._TK_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TICKETNO", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string TICKETNO
		{
			get
			{
				return this._TICKETNO;
			}
			set
			{
				if ((this._TICKETNO != value))
				{
					this._TICKETNO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WHCODE", DbType="VarChar(10)")]
		public string WHCODE
		{
			get
			{
				return this._WHCODE;
			}
			set
			{
				if ((this._WHCODE != value))
				{
					this._WHCODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WHNAME", DbType="VarChar(10)")]
		public string WHNAME
		{
			get
			{
				return this._WHNAME;
			}
			set
			{
				if ((this._WHNAME != value))
				{
					this._WHNAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AREA", DbType="VarChar(20)")]
		public string AREA
		{
			get
			{
				return this._AREA;
			}
			set
			{
				if ((this._AREA != value))
				{
					this._AREA = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DETAIL", DbType="VarChar(500)")]
		public string DETAIL
		{
			get
			{
				return this._DETAIL;
			}
			set
			{
				if ((this._DETAIL != value))
				{
					this._DETAIL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STCODE", DbType="VarChar(5)")]
		public string STCODE
		{
			get
			{
				return this._STCODE;
			}
			set
			{
				if ((this._STCODE != value))
				{
					this._STCODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATEDATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> CREATEDATE
		{
			get
			{
				return this._CREATEDATE;
			}
			set
			{
				if ((this._CREATEDATE != value))
				{
					this._CREATEDATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATETIME", DbType="VarChar(30)")]
		public string CREATETIME
		{
			get
			{
				return this._CREATETIME;
			}
			set
			{
				if ((this._CREATETIME != value))
				{
					this._CREATETIME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TNAME", DbType="NVarChar(50)")]
		public string TNAME
		{
			get
			{
				return this._TNAME;
			}
			set
			{
				if ((this._TNAME != value))
				{
					this._TNAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BRAND", DbType="VarChar(5)")]
		public string BRAND
		{
			get
			{
				return this._BRAND;
			}
			set
			{
				if ((this._BRAND != value))
				{
					this._BRAND = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SS_ID", DbType="Int")]
		public System.Nullable<int> SS_ID
		{
			get
			{
				return this._SS_ID;
			}
			set
			{
				if ((this._SS_ID != value))
				{
					this._SS_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FLAG", DbType="VarChar(50)")]
		public string FLAG
		{
			get
			{
				return this._FLAG;
			}
			set
			{
				if ((this._FLAG != value))
				{
					this._FLAG = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ORDERNO", DbType="Int NOT NULL")]
		public int ORDERNO
		{
			get
			{
				return this._ORDERNO;
			}
			set
			{
				if ((this._ORDERNO != value))
				{
					this._ORDERNO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TK_MESAGE", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string TK_MESAGE
		{
			get
			{
				return this._TK_MESAGE;
			}
			set
			{
				if ((this._TK_MESAGE != value))
				{
					this._TK_MESAGE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_US_ID", DbType="VarChar(5)")]
		public string US_ID
		{
			get
			{
				return this._US_ID;
			}
			set
			{
				if ((this._US_ID != value))
				{
					this._US_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DETAILDATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> DETAILDATE
		{
			get
			{
				return this._DETAILDATE;
			}
			set
			{
				if ((this._DETAILDATE != value))
				{
					this._DETAILDATE = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DEV_TASK_FLAG")]
	public partial class DEV_TASK_FLAG : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Type_name;
		
		private System.Nullable<int> _FLAG;
		
		private string _File_img;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnType_nameChanging(string value);
    partial void OnType_nameChanged();
    partial void OnFLAGChanging(System.Nullable<int> value);
    partial void OnFLAGChanged();
    partial void OnFile_imgChanging(string value);
    partial void OnFile_imgChanged();
    #endregion
		
		public DEV_TASK_FLAG()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type_name", DbType="VarChar(10)")]
		public string Type_name
		{
			get
			{
				return this._Type_name;
			}
			set
			{
				if ((this._Type_name != value))
				{
					this.OnType_nameChanging(value);
					this.SendPropertyChanging();
					this._Type_name = value;
					this.SendPropertyChanged("Type_name");
					this.OnType_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FLAG", DbType="Int")]
		public System.Nullable<int> FLAG
		{
			get
			{
				return this._FLAG;
			}
			set
			{
				if ((this._FLAG != value))
				{
					this.OnFLAGChanging(value);
					this.SendPropertyChanging();
					this._FLAG = value;
					this.SendPropertyChanged("FLAG");
					this.OnFLAGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_File_img", DbType="VarChar(255)")]
		public string File_img
		{
			get
			{
				return this._File_img;
			}
			set
			{
				if ((this._File_img != value))
				{
					this.OnFile_imgChanging(value);
					this.SendPropertyChanging();
					this._File_img = value;
					this.SendPropertyChanged("File_img");
					this.OnFile_imgChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
