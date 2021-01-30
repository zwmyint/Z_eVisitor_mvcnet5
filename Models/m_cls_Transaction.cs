using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eVisitor_mvcnet5.Models
{
    public class m_cls_Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Column(TypeName ="nvarchar(12)")]
        [DisplayName("Account Number")]
        [Required(ErrorMessage ="This Field is required.")]
        [MaxLength(12,ErrorMessage ="Maximum 12 characters only")]
        public string AccountNumber { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        [DisplayName("Beneficiary Name")]
        [Required(ErrorMessage = "This Field is required.")]
        public string BeneficiaryName { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        [DisplayName("Bank Name")]
        [Required(ErrorMessage = "This Field is required.")]
        public string BankName { get; set; }

        [Column(TypeName ="nvarchar(11)")]
        [DisplayName("SWIFT Code")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(11)]
        public string SWIFTCode { get; set; }

        [DisplayName("Amount")]
        [Required(ErrorMessage = "This Field is required.")]
        public decimal TranAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TranDate { get; set; }
    }

}