﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace ManageStatsWebService {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class puzzleRUN_DataSet : DataSet {
        
        private puzzleRUNDataTable tablepuzzleRUN;
        
        public puzzleRUN_DataSet() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected puzzleRUN_DataSet(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["puzzleRUN"] != null)) {
                    this.Tables.Add(new puzzleRUNDataTable(ds.Tables["puzzleRUN"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public puzzleRUNDataTable puzzleRUN {
            get {
                return this.tablepuzzleRUN;
            }
        }
        
        public override DataSet Clone() {
            puzzleRUN_DataSet cln = ((puzzleRUN_DataSet)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(XmlReader reader) {
            this.Reset();
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["puzzleRUN"] != null)) {
                this.Tables.Add(new puzzleRUNDataTable(ds.Tables["puzzleRUN"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.tablepuzzleRUN = ((puzzleRUNDataTable)(this.Tables["puzzleRUN"]));
            if ((this.tablepuzzleRUN != null)) {
                this.tablepuzzleRUN.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "puzzleRUN_DataSet";
            this.Prefix = "";
            this.Namespace = "";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tablepuzzleRUN = new puzzleRUNDataTable();
            this.Tables.Add(this.tablepuzzleRUN);
        }
        
        private bool ShouldSerializepuzzleRUN() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void puzzleRUNRowChangeEventHandler(object sender, puzzleRUNRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class puzzleRUNDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnExecutionID;
            
            private DataColumn columnDictionary;
            
            private DataColumn columnPuzzle;
            
            private DataColumn columnWordsFound;
            
            private DataColumn columnDictionaryTime;
            
            private DataColumn columnPuzzleTime;
            
            private DataColumn columnSolutionTime;
            
            internal puzzleRUNDataTable() : 
                    base("puzzleRUN") {
                this.InitClass();
            }
            
            internal puzzleRUNDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn ExecutionIDColumn {
                get {
                    return this.columnExecutionID;
                }
            }
            
            internal DataColumn DictionaryColumn {
                get {
                    return this.columnDictionary;
                }
            }
            
            internal DataColumn PuzzleColumn {
                get {
                    return this.columnPuzzle;
                }
            }
            
            internal DataColumn WordsFoundColumn {
                get {
                    return this.columnWordsFound;
                }
            }
            
            internal DataColumn DictionaryTimeColumn {
                get {
                    return this.columnDictionaryTime;
                }
            }
            
            internal DataColumn PuzzleTimeColumn {
                get {
                    return this.columnPuzzleTime;
                }
            }
            
            internal DataColumn SolutionTimeColumn {
                get {
                    return this.columnSolutionTime;
                }
            }
            
            public puzzleRUNRow this[int index] {
                get {
                    return ((puzzleRUNRow)(this.Rows[index]));
                }
            }
            
            public event puzzleRUNRowChangeEventHandler puzzleRUNRowChanged;
            
            public event puzzleRUNRowChangeEventHandler puzzleRUNRowChanging;
            
            public event puzzleRUNRowChangeEventHandler puzzleRUNRowDeleted;
            
            public event puzzleRUNRowChangeEventHandler puzzleRUNRowDeleting;
            
            public void AddpuzzleRUNRow(puzzleRUNRow row) {
                this.Rows.Add(row);
            }
            
            public puzzleRUNRow AddpuzzleRUNRow(object[] Dictionary, char[][][] Puzzle, object[] WordsFound, System.DateTime DictionaryTime, System.DateTime PuzzleTime, System.DateTime SolutionTime) {
                puzzleRUNRow rowpuzzleRUNRow = ((puzzleRUNRow)(this.NewRow()));
                rowpuzzleRUNRow.ItemArray = new object[] {
                        null,
                        Dictionary,
                        Puzzle,
                        WordsFound,
                        DictionaryTime,
                        PuzzleTime,
                        SolutionTime};
                this.Rows.Add(rowpuzzleRUNRow);
                return rowpuzzleRUNRow;
            }
            
            public puzzleRUNRow FindByExecutionID(int ExecutionID) {
                return ((puzzleRUNRow)(this.Rows.Find(new object[] {
                            ExecutionID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                puzzleRUNDataTable cln = ((puzzleRUNDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new puzzleRUNDataTable();
            }
            
            internal void InitVars() {
                this.columnExecutionID = this.Columns["ExecutionID"];
                this.columnDictionary = this.Columns["Dictionary"];
                this.columnPuzzle = this.Columns["Puzzle"];
                this.columnWordsFound = this.Columns["WordsFound"];
                this.columnDictionaryTime = this.Columns["DictionaryTime"];
                this.columnPuzzleTime = this.Columns["PuzzleTime"];
                this.columnSolutionTime = this.Columns["SolutionTime"];
            }
            
            private void InitClass() {
                this.columnExecutionID = new DataColumn("ExecutionID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnExecutionID);
                this.columnDictionary = new DataColumn("Dictionary", typeof(object[]), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnDictionary);
                this.columnPuzzle = new DataColumn("Puzzle", typeof(char[][][]), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPuzzle);
                this.columnWordsFound = new DataColumn("WordsFound", typeof(object[]), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnWordsFound);
                this.columnDictionaryTime = new DataColumn("DictionaryTime", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnDictionaryTime);
                this.columnPuzzleTime = new DataColumn("PuzzleTime", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPuzzleTime);
                this.columnSolutionTime = new DataColumn("SolutionTime", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnSolutionTime);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnExecutionID}, true));
                this.columnExecutionID.AutoIncrement = true;
                this.columnExecutionID.AllowDBNull = false;
                this.columnExecutionID.Unique = true;
                this.columnDictionary.AllowDBNull = false;
                this.columnPuzzle.AllowDBNull = false;
                this.columnWordsFound.AllowDBNull = false;
                this.columnDictionaryTime.AllowDBNull = false;
                this.columnPuzzleTime.AllowDBNull = false;
                this.columnSolutionTime.AllowDBNull = false;
            }
            
            public puzzleRUNRow NewpuzzleRUNRow() {
                return ((puzzleRUNRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new puzzleRUNRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(puzzleRUNRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.puzzleRUNRowChanged != null)) {
                    this.puzzleRUNRowChanged(this, new puzzleRUNRowChangeEvent(((puzzleRUNRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.puzzleRUNRowChanging != null)) {
                    this.puzzleRUNRowChanging(this, new puzzleRUNRowChangeEvent(((puzzleRUNRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.puzzleRUNRowDeleted != null)) {
                    this.puzzleRUNRowDeleted(this, new puzzleRUNRowChangeEvent(((puzzleRUNRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.puzzleRUNRowDeleting != null)) {
                    this.puzzleRUNRowDeleting(this, new puzzleRUNRowChangeEvent(((puzzleRUNRow)(e.Row)), e.Action));
                }
            }
            
            public void RemovepuzzleRUNRow(puzzleRUNRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class puzzleRUNRow : DataRow {
            
            private puzzleRUNDataTable tablepuzzleRUN;
            
            internal puzzleRUNRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tablepuzzleRUN = ((puzzleRUNDataTable)(this.Table));
            }
            
            public int ExecutionID {
                get {
                    return ((int)(this[this.tablepuzzleRUN.ExecutionIDColumn]));
                }
                set {
                    this[this.tablepuzzleRUN.ExecutionIDColumn] = value;
                }
            }
            
            public object[] Dictionary {
                get {
                    return ((object[])(this[this.tablepuzzleRUN.DictionaryColumn]));
                }
                set {
                    this[this.tablepuzzleRUN.DictionaryColumn] = value;
                }
            }
            
            public char[][][] Puzzle {
                get {
                    return ((char[][][])(this[this.tablepuzzleRUN.PuzzleColumn]));
                }
                set {
                    this[this.tablepuzzleRUN.PuzzleColumn] = value;
                }
            }
            
            public object[] WordsFound {
                get {
                    return ((object[])(this[this.tablepuzzleRUN.WordsFoundColumn]));
                }
                set {
                    this[this.tablepuzzleRUN.WordsFoundColumn] = value;
                }
            }
            
            public System.DateTime DictionaryTime {
                get {
                    return ((System.DateTime)(this[this.tablepuzzleRUN.DictionaryTimeColumn]));
                }
                set {
                    this[this.tablepuzzleRUN.DictionaryTimeColumn] = value;
                }
            }
            
            public System.DateTime PuzzleTime {
                get {
                    return ((System.DateTime)(this[this.tablepuzzleRUN.PuzzleTimeColumn]));
                }
                set {
                    this[this.tablepuzzleRUN.PuzzleTimeColumn] = value;
                }
            }
            
            public System.DateTime SolutionTime {
                get {
                    return ((System.DateTime)(this[this.tablepuzzleRUN.SolutionTimeColumn]));
                }
                set {
                    this[this.tablepuzzleRUN.SolutionTimeColumn] = value;
                }
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class puzzleRUNRowChangeEvent : EventArgs {
            
            private puzzleRUNRow eventRow;
            
            private DataRowAction eventAction;
            
            public puzzleRUNRowChangeEvent(puzzleRUNRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public puzzleRUNRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}