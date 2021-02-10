# DotNet.Misc
[![Build Status](https://carlubian.visualstudio.com/DotNet.Misc/_apis/build/status/DotNet.Misc%20Build)](https://carlubian.visualstudio.com/DotNet.Misc/_build/latest?definitionId=16)

This repository contains several minor libraries providing utility and convenience.

## DotNet.Misc.Collections
Injects a new class <strong>LenientDictionary&lt;TKey, TValue&gt;</strong> into the System.Collections.Generic namespace.

A LenientDictionary behaves as a regular Dictionary, but offers a more <em>lenient</em> operation:
* Calls to .Add() when the key is already present in the LenientDictionary won't throw an exception. Instead, the value will be overwritten.
* Using the indexer to get an element whose key is not present in the LenientDictionary won't throw an exception. Instead, a default value will be returned.

Additionally, the .ContainsValue() method is addded as an extension for IDictionary&lt;TKey, TValue&gt;, having a similar behaviour as the standard .ContainsKey().
