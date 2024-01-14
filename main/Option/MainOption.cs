using CommandLine;

namespace main.Option;

public class MainOption
{
    [Option('t', 
    "type", 
    HelpText = "The lazy punching card to automate. The expected values are.")]
    public ICollection<string> Type
    {
        get;
        set;
    } = [];
    
    [Option('u',
    "username",
    HelpText = "The username of the account")]
    public string? Account
    {
        get;
        set;
    }
    
    [Option('p',
    "password",
    HelpText = "The password of the account")]
    public string? Password
    {
        get;
        set;
    }

    [Option('a',
    "add-args",
    HelpText = "The additional parameters.")]
    public ICollection<string> AdditionalArguments
    {
        get;
        set;
    } = [];
    
    [Option('v',
    "version",
    HelpText = "Display version information\n")]
    public bool Version
    {
        get;
        set;
    }
}