using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Umbraco.Core.Models.Entities;

namespace Umbraco.Core.Models
{
    public interface IPropertyType : IEntity, IRememberBeingDirty
    {
        /// <summary>
        /// Gets of sets the name of the property type.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets of sets the alias of the property type.
        /// </summary>
        string Alias { get; set; }

        /// <summary>
        /// Gets of sets the description of the property type.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the datatype for this property type.
        /// </summary>
        int DataTypeId { get; set; }

        Guid DataTypeKey { get; set; }

        /// <summary>
        /// Gets or sets the alias of the property editor for this property type.
        /// </summary>
        string PropertyEditorAlias { get; set; }

        /// <summary>
        /// Gets or sets the database type for storing value for this property type.
        /// </summary>
        ValueStorageType ValueStorageType { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the property group this property type belongs to.
        /// </summary>
        /// <remarks>For generic properties, the value is <c>null</c>.</remarks>
        Lazy<int> PropertyGroupId { get; set; }

        /// <summary>
        /// Gets of sets a value indicating whether a value for this property type is required.
        /// </summary>
        bool Mandatory { get; set; }

        /// <summary>
        /// Gets of sets the sort order of the property type.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the regular expression validating the property values.
        /// </summary>
        string ValidationRegExp { get; set; }

        bool SupportsPublishing { get; set;  }

        /// <summary>
        /// Gets or sets the content variation of the property type.
        /// </summary>
        ContentVariation Variations { get; set; }

        /// <summary>
        /// Determines whether the property type supports a combination of culture and segment.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="segment">The segment.</param>
        /// <param name="wildcards">A value indicating whether wildcards are valid.</param>
        bool SupportsVariation(string culture, string segment, bool wildcards = false);

        /// <summary>
        /// Converts a value assigned to a property.
        /// </summary>
        /// <remarks>
        /// <para>The input value can be pretty much anything, and is converted to the actual CLR type
        /// expected by the property (eg an integer if the property values are integers).</para>
        /// <para>Throws if the value cannot be converted.</para>
        /// </remarks>
        object ConvertAssignedValue(object value);
    }
}
