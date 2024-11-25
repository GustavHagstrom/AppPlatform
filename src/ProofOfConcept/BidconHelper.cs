using BidCon.SDK.Database;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace ConsoleApp1;
internal static class BidconHelper
{
    public static DatabaseUser CreateUser()
    {
        var connection = ConnectionFromIni();
        var usr = (DatabaseUser)RuntimeHelpers.GetUninitializedObject(typeof(DatabaseUser));

        ReflectionHelper.SetFieldValue(usr, "<Name>k__BackingField", "Admin");
        ReflectionHelper.SetFieldValue(usr, "<ID>k__BackingField", 2);
        ReflectionHelper.SetFieldValue(usr, "<UserGroup>k__BackingField", 2);
        
        ReflectionHelper.SetFieldValue(usr, "<EstimationAccess>k__BackingField", CreateEstimationAccess(connection, usr));
        ReflectionHelper.SetFieldValue(usr, "_estimationReader", CreateEstimationReader(connection, usr));
        ReflectionHelper.SetFieldValue(usr, "_systemReader", CreateSystemReader(connection));

        // Define key and value types dynamically
        Type keyType = typeof(string);
        Type valueType = Type.GetType("BidCon.SDK.Database.DatabaseEstimationWriter, BidCon.SDK, Version=2023.2.0.0, Culture=neutral, PublicKeyToken=d5af2ed775e84a93")!;

        // Create a generic Dictionary<TKey, TValue> type
        Type dictionaryType = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);

        // Instantiate the dictionary
        object dictionary = System.Activator.CreateInstance(dictionaryType)!;

        ReflectionHelper.SetFieldValue(usr, "EstimationWriters", dictionary);
        ReflectionHelper.SetFieldValue(usr, "<Connection>k__BackingField", connection);



        return usr;
    }
    public static object CreateEstimationAccess(object connection, DatabaseUser user)
    {
        var accessType = Type.GetType("BidCon.SDK.Database.DatabaseEstimationAccess, BidCon.SDK, Version=2023.2.0.0, Culture=neutral, PublicKeyToken=d5af2ed775e84a93");
        var instance = ReflectionHelper.CreateInstance(accessType!, [user, connection]);
        return instance;
    }
    public static DatabaseEstimationReader CreateEstimationReader(object connection, DatabaseUser user)
    {
        var reader = ReflectionHelper.CreateInstance<DatabaseEstimationReader>(user, connection);
        return reader;
    }
    public static DatabaseSystemReader CreateSystemReader(object connection)
    {
        var reader = ReflectionHelper.CreateInstance<DatabaseSystemReader>(connection);
        return reader;
    }
    public static object ConnectionFromIni()
    {
        var app = BidCon.SDK.Activator.CreateApp();
        app.InitConnectionFromIni();
        return ReflectionHelper.GetFieldOrPropertyValue<object>(app, "_connection");
    }
    public static SqlConnection GetSystemConnection()
    {
        return new SqlConnection("Data Source=RHUSAPP02\\ELECOSOFT;Initial Catalog=BidConSystem;User ID=sa;Password=Putlig@15;Connect Timeout=30;Encrypt=False;");
    }
    public static SqlConnection GetEstimationConnection()
    {
        return new SqlConnection("Data Source=RHUSAPP02\\ELECOSOFT;Initial Catalog=BidConEstimation;User ID=sa;Password=Putlig@15;Connect Timeout=30;Encrypt=False;");
    }

}
