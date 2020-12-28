using System.Collections.Generic;
using SurveyNet.Domain;

namespace SurveyNet.Documentation.DataLayer.Repositories {
    public interface ISurveyRepository {
        IEnumerable<Survey> Surveys { get; }
    }
}