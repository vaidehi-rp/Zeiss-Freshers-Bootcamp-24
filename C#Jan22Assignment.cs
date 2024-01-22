using System;
using System.Collections.Generic;
using System.Reflection;


abstract class ValidationAttribute : Attribute
{
    public abstract List<string> Validate(object value);
}

class RequiredAttribute : ValidationAttribute
{
    public override List<string> Validate(object value)
    {
        List<string> errors = new List<string>();
        if (value == null)
        {
            errors.Add("Property requires a value");
        }
        return errors;
    }
}

class RangeAttribute : ValidationAttribute
{
    private int _min;
    private int _max;

    public RangeAttribute(int min, int max)
    {
        _min = min;
        _max = max;
    }

    public override List<string> Validate(object value)
    {
        List<string> errors = new List<string>();
        if ((int)value < _min || (int)value > _max)
        {
            errors.Add($"Value must be between {_min} and {_max}");
        }
        return errors;
    }
}

class MaxLengthAttribute : ValidationAttribute
{
    private int _maxLength;

    public MaxLengthAttribute(int maxLength)
    {
        _maxLength = maxLength;
    }

    public override List<string> Validate(object value)
    {
        List<string> errors = new List<string>();
        if (((string)value).Length > _maxLength)
        {
            errors.Add($"Maximum length is {_maxLength} characters");
        }
        return errors;
    }
}

class Device
{
    [Required]
    public string Id { get; set; }

    [Range(10, 100)]
    public int Code { get; set; }

    [MaxLength(100)]
    public string Description { get; set; }
}

class Program
{
    static void Main()
    {
        Device deviceObj = new Device();
        List<string> errors = ValidateDevice(deviceObj);

        if (errors.Count > 0)
        {
            foreach (string item in errors)
            {
                Console.WriteLine(item);
            }
        }
    }

    static List<string> ValidateDevice(Device device)
    {
        List<string> errors = new List<string>();
        Type type = typeof(Device);
        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            object[] attributes = property.GetCustomAttributes(true);
            foreach (object attribute in attributes)
            {
                if (attribute is ValidationAttribute validationAttribute)
                {
                    List<string> attributeErrors = validationAttribute.Validate(property.GetValue(device));
                    errors.AddRange(attributeErrors);
                }
            }
        }

        return errors;
    }
}
