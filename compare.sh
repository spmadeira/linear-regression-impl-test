#!/bin/bash
cd ./py
echo "Scikit Learn output:"
python3 main.py
cd ../cs
echo "C# implementation output:"
dotnet run
cd ../