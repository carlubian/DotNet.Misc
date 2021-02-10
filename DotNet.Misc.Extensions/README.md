# DotNet.Misc
[![Build Status](https://carlubian.visualstudio.com/DotNet.Misc/_apis/build/status/DotNet.Misc%20Build)](https://carlubian.visualstudio.com/DotNet.Misc/_build/latest?definitionId=16)

This repository contains several minor libraries providing utility and convenience.

## DotNet.Misc.Extensions
Offers utility extension methods:
* IEnumerable.ForEach: Execute an action on every element in the sequence, consuming them.
* IEnumerable.Peek: Execute an action on every element in the sequence, without consuming them.
* T.Generate: Produce an infinite sequence from an object and a generator function.
* T.Enumerate: Produce a sequence with a single element in it.
* IEnumerable.Stringify: Convert a sequence into a string, with an optional separator.
* IEnumerable.Random: Return a random element within the sequence.
