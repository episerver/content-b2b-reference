namespace Sample.Services;

public class BaseService
{
    //public virtual UserContext UserContext { get; set; }

    public BaseService()
    {
        //if (HttpContext.Current != null)
        //{
        //    UserContext = HttpContext.Current.Session["UserContext"] as UserContext;
        //    if (UserContext == null)
        //    {
        //        UserContext = new UserContext();
        //    }
        //}
        //else
        //{
        //    if (UserContext == null)
        //    {
        //        UserContext = new UserContext();
        //    }
        //}
    }

    //public BaseService(UserContext userContext)
    //{
    //    UserContext = userContext;
    //}

    //public virtual void SetContext(UserContext userContext)
    //{

    //}

    //public virtual UserContext GetContext()
    //{
    //    var userContext = HttpContext.Current.Session["UserContext"] as UserContext;
    //    if (userContext == null)
    //    {
    //        userContext = new UserContext();
    //    }

    //    return userContext;
    //}
}
