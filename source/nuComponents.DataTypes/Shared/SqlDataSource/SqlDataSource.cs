﻿
namespace nuComponents.DataTypes.Shared.SqlDataSource
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using umbraco.DataLayer;
    using nuComponents.DataTypes.Shared.Picker;

    public class SqlDataSource
    {
        public string SqlExpression { get; set; }

        public string ConnectionString { get; set; }

        public IEnumerable<PickerEditorOption> GetEditorOptions()
        {
            List<PickerEditorOption> pickerEditorOptions = new List<PickerEditorOption>();

            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[this.ConnectionString];            
            if (connectionStringSettings != null)
            {
                using (ISqlHelper sqlHelper = DataLayerHelper.CreateSqlHelper(connectionStringSettings.ConnectionString))
                {
                    // TODO: token replacement eg. @currentId

                    using(IRecordsReader recordsReader = sqlHelper.ExecuteReader(this.SqlExpression))
                    {
                        if(recordsReader != null)
                        {
                            while(recordsReader.Read())
                            {
                                pickerEditorOptions.Add(
                                    new PickerEditorOption()
                                    {
                                        Key = recordsReader.GetObject("Key") as string,
                                        Markup = recordsReader.GetObject("Label") as string
                                    }
                                );
                            }
                        }
                    }
                }
            }

            return pickerEditorOptions;
        }
    }
}
