﻿namespace Construktion.Blueprints.Simple
{
    using System;

    public class AttributeBlueprint<T> : AbstractAttributeBlueprint<T> where T : Attribute
    {
        private readonly Func<T, object> _value;

        public AttributeBlueprint(Func<T, object> value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _value = value;
        }

        public override object Construct(ConstruktionContext context, ConstruktionPipeline pipeline)
        {
            var value = _value(GetAttribute(context));

            return value;
        }
    }
}