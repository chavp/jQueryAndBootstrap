using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.BusinessModels
{
    public class EApplicationVisa 
        : Entity
    {
        public virtual Member Member { get; protected set; }
        public virtual EApplicationVisaStatus Status { get; set; }

        /// <summary>
        /// format. BR001YYYYMMDD######0
        /// example. BR001201501010000001
        /// </summary>
        public virtual string RequestCode { get; protected set; }
        public virtual void GenRequestCode()
        {
            //byte[] b = BitConverter.GetBytes(ID);

            // Return the Base64-encoded int.


            string code = IntToString(ID,
            new char[] { '0','1','2','3','4','5','6','7','8','9',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'}, 13);

            RequestCode = BranchOfOperation.Code + code;


        }

        public virtual string IntToString(long value, char[] baseChars, int pading)
        {
            string result = string.Empty;
            int targetBase = baseChars.Length;

            do
            {
                result = baseChars[value % targetBase] + result;
                value = value / targetBase;
            }
            while (value > 0);

            while (result.Length < pading)
            {
                result = "0" + result;
            }

            return result;
        }

        // Personal Information
        public virtual VisaType VisaType { get; set; }
        public virtual int NumberOfEntriesRequested { get; set; }
        public virtual Title Title { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string FamilyName { get; set; }
        public virtual string FormerName { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Marital Marital { get; set; }
        public virtual Country CountryForTravelValid  { get; set; }
        public virtual Nation Nationality { get; set; }
        public virtual Nation NationalityAtBirth { get; set; }
        public virtual Country BirthPlace { get; set; }
        public virtual DateTime? DateOfBirth  { get; set; }
        public virtual string Occupation { get; set; }
        public virtual string CurrentAddress { get; set; }
        public virtual string CurrentAddressTel { get; set; }
        public virtual string Email { get; set; }
        public virtual string PermanentAddress  { get; set; }
        public virtual string PermanentAddressTel { get; set; }
        public virtual string NamesDatesPlacesOfMinorChildren { get; set; }

        // Travelling Information
        public virtual Unit BranchOfOperation  { get; set; }
        public virtual DateTime? DateOfArrivalInThailand { get; set; }
        public virtual Travelling Travelling { get; set; }
        public virtual string FlightNo { get; set; }
        public virtual int DurationOfProposedStay { get; set; }
        public virtual DateTime? DateOfPreviousVisit { get; set; }
        public virtual PurposeOfVisit PurposeOfVisit { get; set; }
        public virtual string AgentNo { get; set; }
        public virtual string AgentName { get; set; }
        public virtual string ProposedAddressInThailand { get; set; }
        public virtual string NamesAndAddressOfLocalGuarantor { get; set; }
        public virtual string NamesAndAddressOfLocalGuarantorTel { get; set; }
        public virtual string NamesAndAddressOfGuarantorInThailand { get; set; }
        public virtual string NamesAndAddressOfGuarantorInThailandTel { get; set; }

        // Image and Documents
        public virtual string ImagePath { get; set; }
        public virtual string PassportPath { get; set; }
        public virtual string AirTicketPath { get; set; }
        public virtual string FinancialPath { get; set; }

        // Passport Information
        public virtual string PassportNo { get; set; }
        public virtual Country PassportIssuedAt { get; set; }
        public virtual DateTime? DateOfIssue { get; set; }
        public virtual DateTime? ExpiryDate { get; set; }

        protected EApplicationVisa() { }

        public EApplicationVisa(
            Member member, 
            EApplicationVisaStatus status,
            VisaType visaType,
            
            // Personal Information
            Title title,
            string firstName,
            string familyName,
            Nation nationality,
            Nation nationalityAtBirth,
            Country birthPlace,
            Gender gender,
            Marital maritalStatus,
            DateTime dateOfBirth,
            string currentAddress,
            string currentAddressTel,
            string email,
            string permanentAddress,
            string permanentAddressTel,
            Country countryForTravelValid,

            // Image and Documents
            string imagePath,
            string passportPath,
            string airTicketPath,
            string financialPath,

            // Travelling Information
            Unit branchOfOperation, 
            DateTime dateOfArrivalInThailand, 
            Travelling travelling,
            string flightNo, 
            int durationOfProposedStay, 
            DateTime dateOfPreviousVisit, 
            PurposeOfVisit purposeOfVisit,
            string proposedAddressInThailand,

            // Passport Information
            string passportNo, 
            Country passportIssuedAt, 
            DateTime dateOfIssue, 
            DateTime expiryDate
            )
        {
            if (member == null) throw new ArgumentNullException("Please require Member");
            //if (string.IsNullOrEmpty(requestCode)) throw new ArgumentNullException("Please require RequestCode");
            //if (requestCode.Length != 21) throw new ArgumentOutOfRangeException("Please RequestCode must have length equal 20");
            if (status == null) throw new ArgumentNullException("Please require Status");

            if (title == null) throw new ArgumentNullException("Please require Title");
            if (string.IsNullOrEmpty(firstName)) throw new ArgumentNullException("Please require First Name");
            if (string.IsNullOrEmpty(familyName)) throw new ArgumentNullException("Please require Family Name");
            if (nationality == null) throw new ArgumentNullException("Please require Nationality");
            if (nationalityAtBirth == null) throw new ArgumentNullException("Please require Nationality At Birth");
            if (birthPlace == null) throw new ArgumentNullException("Please require Birth Place");
            if (gender == null) throw new ArgumentNullException("Please require Gender");
            if (maritalStatus == null) throw new ArgumentNullException("Please require Marital Status");
            if (string.IsNullOrEmpty(currentAddress)) throw new ArgumentNullException("Please require Current Address");
            if (string.IsNullOrEmpty(currentAddressTel)) throw new ArgumentNullException("Please require Current Address Tel");
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException("Please require Email");
            if (string.IsNullOrEmpty(permanentAddress)) throw new ArgumentNullException("Please require Permanent Address");
            if (string.IsNullOrEmpty(permanentAddressTel)) throw new ArgumentNullException("Please require Permanent Address Tel");
            if (countryForTravelValid == null) throw new ArgumentNullException("Please require Country For Travel Valid");

            if (string.IsNullOrEmpty(imagePath)) throw new ArgumentNullException("Please require Image Path");
            if (string.IsNullOrEmpty(passportPath)) throw new ArgumentNullException("Please require Passport Path");
            if (string.IsNullOrEmpty(airTicketPath)) throw new ArgumentNullException("Please require AIR Ticket Path");
            if (string.IsNullOrEmpty(financialPath)) throw new ArgumentNullException("Please require Financial Path");

            if (branchOfOperation == null) throw new ArgumentNullException("Please require Branch Of Operation");
            if (travelling == null) throw new ArgumentNullException("Please require Travelling");
            if (string.IsNullOrEmpty(flightNo)) throw new ArgumentNullException("Please require Flight No");
            if (purposeOfVisit == null) throw new ArgumentNullException("Please require Purpose Of Visit");
            if (string.IsNullOrEmpty(proposedAddressInThailand)) throw new ArgumentNullException("Please require Proposed Address In Thailand");

            if (string.IsNullOrEmpty(passportNo)) throw new ArgumentNullException("Please require Passport No");
            if (passportIssuedAt == null) throw new ArgumentNullException("Please require Passport Issued At");

            Member = member;
            //RequestCode = requestCode;
            Status = status;
            VisaType = visaType;

            // Personal Information
            Title = title;
            FirstName = firstName;
            FamilyName = familyName;
            Nationality = nationality;
            NationalityAtBirth = nationalityAtBirth;
            BirthPlace = birthPlace;
            Gender = gender;
            Marital = maritalStatus;
            DateOfBirth = dateOfBirth.Date;
            CurrentAddress = currentAddress;
            CurrentAddressTel = currentAddressTel;
            Email = email;
            PermanentAddress = permanentAddress;
            PermanentAddressTel = permanentAddressTel;
            CountryForTravelValid = countryForTravelValid;

            // Image and Documents
            ImagePath = imagePath;
            PassportPath = passportPath;
            AirTicketPath = airTicketPath;
            FinancialPath = financialPath;

            // Travelling Information
            BranchOfOperation = branchOfOperation;
            DateOfArrivalInThailand = dateOfArrivalInThailand.Date;
            Travelling = travelling;
            FlightNo = flightNo;
            DurationOfProposedStay = durationOfProposedStay;
            DateOfPreviousVisit = dateOfPreviousVisit.Date;
            PurposeOfVisit = purposeOfVisit;
            ProposedAddressInThailand = proposedAddressInThailand;

            // Passport Information
            PassportNo = passportNo;
            PassportIssuedAt = passportIssuedAt;
            DateOfIssue = dateOfIssue.Date;
            ExpiryDate = expiryDate.Date;
        }

    }
}
