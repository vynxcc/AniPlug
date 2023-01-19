﻿using AniPlug.API_Wrappers.Consumet.Exceptions;

namespace AniPlug.API_Wrappers.Consumet.Helpers;

internal static class Guard
{
    internal static void IsNotNullOrWhiteSpace(string arg, string argumentName)
    {
        if (string.IsNullOrWhiteSpace(arg))
            throw new ConsumetValidationException("Argument can't be null or whitespace.", argumentName);
    }

    internal static void IsNotNull(object arg, string argumentName)
    {
        if (arg == null) throw new ConsumetValidationException("Argument can't be a null.", argumentName);
    }

    internal static void IsLongerThan2Characters(string arg, string argumentName)
    {
        if (string.IsNullOrWhiteSpace(arg) || arg.Length < 3)
            throw new ConsumetValidationException("Argument must be at least 3 characters long", argumentName);
    }

    internal static void IsGreaterThanZero(long arg, string argumentName)
    {
        if (arg < 1)
            throw new ConsumetValidationException("Argument must be a natural number greater than 0.",
                argumentName);
    }

    internal static void IsLesserOrEqualThan(long arg, long max, string argumentName)
    {
        if (arg > max) throw new ConsumetValidationException($"Argument must not be greater than {max}.", argumentName);
    }

    internal static void IsValid<T>(Func<T, bool> isValidFunc, T arg, string argumentName, string message = null)
    {
        if (isValidFunc(arg)) return;

        if (string.IsNullOrWhiteSpace(message)) message = "Argument is not valid.";

        throw new ConsumetValidationException(message, argumentName);
    }

    internal static void IsValidEnum<TEnum>(TEnum arg, string argumentName) where TEnum : struct, Enum
    {
        if (!Enum.IsDefined(typeof(TEnum), arg))
            throw new ConsumetValidationException("Enum value must be valid", argumentName);
    }

    internal static void IsLetter(char character, string argumentName)
    {
        if (!char.IsLetter(character))
            throw new ConsumetValidationException("Character must be a letter", argumentName);
    }
}