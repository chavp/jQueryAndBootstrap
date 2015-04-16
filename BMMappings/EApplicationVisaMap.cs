using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using FluentNHibernate.Mapping;
    using Cwn.eVisa.BusinessModels;

    public class EApplicationVisaMap
        : EntityMap<EApplicationVisa>
    {
        public EApplicationVisaMap()
            : base("TRN_APP_EVISA", isIDIncrement:false)
        {
            Table("TRN_APP_EVISA");

            Map(x => x.RequestCode, "REQUEST_CODE").Unique().Length(30);

            // Personal Information
            References(x => x.VisaType, "MST_VISA_TYPE_ID").Not.Nullable();
            Map(x => x.NumberOfEntriesRequested, "NO_OF_ENTRIES_REQ");
            References(x => x.Title, "MST_TITLE_ID").Not.Nullable();
            Map(x => x.FirstName, "FIRST_NAME").Length(255).Not.Nullable();
            Map(x => x.MiddleName, "MIDDLE_NAME").Length(255);
            Map(x => x.FamilyName, "FAMILY_NAME").Length(255).Not.Nullable();
            Map(x => x.FormerName, "FORMER_NAME").Length(512);
            References(x => x.Nationality, "NATION_ID").Not.Nullable();
            References(x => x.NationalityAtBirth, "NATION_ID_AT_BIRTH").Not.Nullable();
            References(x => x.BirthPlace, "COUNTRY_ID_BIRTH_PLACE").Not.Nullable();
            References(x => x.Gender, "MST_APP_GENDER_ID").Not.Nullable();
            References(x => x.Marital, "MST_APP_MARITAL_ID").Not.Nullable();
            Map(x => x.DateOfBirth, "DATE_OF_BIRTH").CustomSqlType("DATE").Not.Nullable();
            Map(x => x.Occupation, "OCCUPATION").Length(255);
            Map(x => x.CurrentAddress, "CURRENT_ADD").Length(2000).Not.Nullable();
            Map(x => x.CurrentAddressTel, "CURRENT_TEL").Length(50).Not.Nullable();
            Map(x => x.Email, "EMAIL").Length(100).Not.Nullable();
            Map(x => x.PermanentAddress, "PERMANENT_ADD").Length(2000).Not.Nullable();
            Map(x => x.PermanentAddressTel, "PERMANENT_TEL").Length(50).Not.Nullable();
            Map(x => x.NamesDatesPlacesOfMinorChildren, "CHILDREN_DTL").Length(2000);
            References(x => x.CountryForTravelValid, "COUNTRY_ID_TRAVEL_VALID").Not.Nullable();

            // Travelling Information
            References(x => x.BranchOfOperation, "MST_UNIT_ID").Not.Nullable();
            Map(x => x.DateOfArrivalInThailand, "DATE_ARRIVAL_THAI").CustomSqlType("DATE").Not.Nullable();
            References(x => x.Travelling, "MST_APP_TRAVELLING_ID").Not.Nullable();
            Map(x => x.FlightNo, "FLIGHT_NO").Length(50).Not.Nullable();
            Map(x => x.DurationOfProposedStay, "DURATION_STAY").Not.Nullable();
            Map(x => x.DateOfPreviousVisit, "DATE_PREVIOUS_VISIT").CustomSqlType("DATE").Not.Nullable();
            References(x => x.PurposeOfVisit, "MST_APP_PURPOSE_VISIT_ID").Not.Nullable();
            Map(x => x.AgentNo, "AGENT_NO").Length(30);
            Map(x => x.AgentName, "AGENT_NAME").Length(255);
            Map(x => x.ProposedAddressInThailand, "PROPOSED_ADD_THA").Length(2000);
            Map(x => x.NamesAndAddressOfLocalGuarantor, "LOCAL_GUATRNTOR_DTL").Length(2000);
            Map(x => x.NamesAndAddressOfLocalGuarantorTel, "LOCAL_GUARANTOR_TEL").Length(50);
            Map(x => x.NamesAndAddressOfGuarantorInThailand, "GUARANTOR_THAI_DTL").Length(2000);
            Map(x => x.NamesAndAddressOfGuarantorInThailandTel, "GUARANTOR_THAI_TEL").Length(50);

            // Image and Documents
            Map(x => x.ImagePath, "IMG_PATH").Length(255).Not.Nullable();
            Map(x => x.PassportPath, "PASSPORT_PATH").Length(255).Not.Nullable();
            Map(x => x.AirTicketPath, "AIR_TICKET_PATH").Length(255).Not.Nullable();
            Map(x => x.FinancialPath, "FINANCIAL_PATH").Length(255).Not.Nullable();

            // Passport Information
            Map(x => x.PassportNo, "PASSPORT_NO").Length(30).Not.Nullable();
            References(x => x.PassportIssuedAt, "COUNTRY_ID_PASSPORT_ISSUED").Not.Nullable();
            Map(x => x.DateOfIssue, "PASSPORT_ISSUE_DATE").CustomSqlType("DATE").Not.Nullable();
            Map(x => x.ExpiryDate, "PASSPORT_EXPIRY_DATE").CustomSqlType("DATE").Not.Nullable();

            // Tracking
            References(x => x.Member, "TRN_AUT_MEMBER_ID").Not.Nullable();
            References(x => x.Status, "TRN_APP_EVISA_STATUS_ID").Not.Nullable();

            MapVersion();
        }
    }
}
