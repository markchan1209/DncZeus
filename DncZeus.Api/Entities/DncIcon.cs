/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-11-14
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * DESCRIPTION:     圖標實體類
 ******************************************/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.Entities
{
    /// <summary>
    /// 圖標實體類
    /// </summary>
    public class DncIcon
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 圖標名稱
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Code { get; set; }
        /// <summary>
        /// 圖標的大小，單位是 px
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        public string Size { get; set; }
        /// <summary>
        /// 圖標顏色
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string Color { get; set; }
        /// <summary>
        /// 自定義圖標
        /// </summary>
        [Column(TypeName = "nvarchar(60)")]
        public string Custom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid CreatedByUserGuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CreatedByUserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ModifiedOn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? ModifiedByUserGuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModifiedByUserName { get; set; }
    }
}
