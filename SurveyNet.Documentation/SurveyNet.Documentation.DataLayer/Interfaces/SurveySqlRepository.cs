using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using SurveyNet.Documentation.DataLayer.Repositories;
using SurveyNet.Domain;

namespace SurveyNet.Documentation.DataLayer.Interfaces {
    public class SurveySqlRepository : ISurveyRepository {
        private readonly IDbConnection connection;

        public SurveySqlRepository(ConnectionOptions options) {
            connection = new SqlConnection(options.ConnectionString);
        }

        public IEnumerable<Survey> Surveys {
            get {
                var e = connection.Query<SurveyRecord>("SELECT * FROM [Surveys]");
                
                
                return new List<Survey>();
            }
        }
    }

    public record SurveyRecord {
        public Guid Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Title { get; set; }
        public string ProgressStatus { get; set; }
    }
}