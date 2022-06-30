using System.Collections.Generic;

namespace ModelJSON
{
    //Эти структуры нужны для того, чтобы распарсить файл с тегами
    public abstract class BaseJSONObject
    {
    }
    public abstract class BaseJSONList<BaseJSONObject>
    {
        public abstract List<BaseJSONObject> ToList();
    }


}
