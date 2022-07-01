using System.Collections.Generic;
using Newtonsoft.Json;

namespace ModelJSON
{
    class EntityRightJSON
    {
        [JsonProperty("view")]
        string view { get; set; }
        [JsonProperty("edit")]
        string edit { get; set; }
        [JsonProperty("add")]
        string add { get; set; }
        [JsonProperty("delete")]
        string delete { get; set; }
        [JsonProperty("export")]
        string export { get; set; }
    }

    class StatusRightJSON
    {
        [JsonProperty("entity_type")]
        string entity_type { get; set; }

        [JsonProperty("pipeline_id")]
        int pipeline_id { get; set; }
        [JsonProperty("status_id")]
        int status_id { get; set; }
        [JsonProperty("rights")]
        EntityRightJSON rights { get; set; }
    }
    class CatalogRightJSON
    {
        [JsonProperty("catalog_id")]
        int catalog_id { get; set; }

        [JsonProperty("rights")]
        EntityRightJSON rights { get; set; }
    }
    class RightsJSON
    {
        [JsonProperty("leads")]
        EntityRightJSON leads { get; set; }

        [JsonProperty("contacts")]
        EntityRightJSON contacts { get; set; }

        [JsonProperty("companies")]
        EntityRightJSON companies { get; set; }

        [JsonProperty("tasks")]
        EntityRightJSON tasks { get; set; }

        [JsonProperty("mail_access")]
        bool mail_access { get; set; }

        [JsonProperty("catalog_access")]
        bool catalog_access { get; set; }
        [JsonProperty("files_access")]
        bool files_access { get; set; }
        [JsonProperty("status_rights")]
        List<StatusRightJSON> status_rights { get; set; }

        [JsonProperty("catalog_rights")]
        List<CatalogRightJSON> catalog_rights { get; set; }

        //[JsonProperty("custom_fields_rights")]
        //string custom_fields_rights { get; set; }

        [JsonProperty("oper_day_reports_view_access")]
        bool oper_day_reports_view_access { get; set; }
        [JsonProperty("oper_day_user_tracking")]
        bool oper_day_user_tracking { get; set; }

        [JsonProperty("is_admin")]
        bool is_admin { get; set; }

        [JsonProperty("is_free")]
        bool is_free { get; set; }

        [JsonProperty("is_active")]
        bool is_active { get; set; }

        //[JsonProperty("group_id")]
        //int group_id { get; set; }

        //[JsonProperty("role_id")]
        //int role_id { get; set; }

        [JsonProperty("_links")]
        LinksJSON _links { get; set; }
    }
    public class UserJSON : BaseJSONObject
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("lang")]
        public string lang { get; set; }
        [JsonProperty("rights")]
        private RightsJSON rights { get; set; }
    }
    class EmbeddedUsersJSON
    {
        [JsonProperty("users")]
        List<UserJSON> users { get; set; }

        public List<UserJSON> ToList()
        {
            return users;
        }
    }
    public class UsersJSON : BaseJSONList<UserJSON>
    {
        [JsonProperty("_total_items")]
        int _total_items { get; set; }

        [JsonProperty("_page")]
        int _page { get; set; }

        [JsonProperty("_page_count")]
        int _page_count { get; set; }

        [JsonProperty("_links")]
        LinksJSON _links { get; set; }

        [JsonProperty("_embedded")]
        EmbeddedUsersJSON _embedded { get; set; }
        public override List<UserJSON> ToList()
        {
            return _embedded.ToList();
        }
    }
}
