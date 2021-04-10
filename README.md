# EigenCore
[![.NET](https://github.com/modios/EigenCore/actions/workflows/dotnet.yml/badge.svg)](https://github.com/modios/EigenCore/actions/workflows/dotnet.yml)

EigenCore C# wrapper for the Eigen library.  
For now provides just a few methods and it's in very early stages.

## Usage 

### Vector Constructors

```csharp

VectorXD v = new VectorXD("1 2 5 6");

VectorXD v = new VectorXD( new double[] { 1, 2, 5, 6 });

Console.WriteLine(v.ToString());

VectorXD, 4:

    1 2 5 6

```

### Basic Vectors
```csharp

VectorXD zeros = VectorXD.Zeros(10);
VectorXD ones =  VectorXD.Ones(10);
VectorXD ident = VectorXD.Identity(10);
VectorXD random = VectorXD.Random(10);
VectorXD linspace = VectorXD.Linespace(1, 10, 10);
```

### Matrix Constructors

```csharp

MatrixXD A = new MatrixXD("1 3 2; 0 2 1");

MatrixXD B = new MatrixXD(new double[][] { new double[] { 1, 3, 2 } , new double[] { 0, 2, 1 } });

MatrixXD C = new MatrixXD(new double[,] { { 1, 3, 2 }, { 0, 2, 1 } });

Console.WriteLine(A.ToString());

MatrixXD, 2 * 3:
    
    1 3 2 
    0 2 1 
```

### Basic Matrices

```csharp

MatrixXD zeros = MatrixXD.Zeros(2, 3);
MatrixXD ones =  MatrixXD.Ones(2, 2);
MatrixXD ident = MatrixXD.Identity(3);
MatrixXD random = MatrixXD.Random(3,3);
MatrixXD diag = MatrixXD.Diag(new[] { 3.5, 2, 4.5 });

```


### Matrix Operations

```csharp

MatrixXD A = new MatrixXD("4 3; 3 2");
MatrixXD B = new MatrixXD("2 2; 1 1");
var result = A.Plus(B);

Console.WriteLine(result.ToString());

MatrixXD, 2 * 2:
    
   6 5 
   4 3
```

```csharp

MatrixXD A = new MatrixXD("1 2; 3 5");
MatrixXD B = new MatrixXD("1 2; 3 2");
MatrixXD result = A.Mult(B);

Console.WriteLine(result.ToString());

MatrixXD, 2 * 2:  

    7 18 
    6 16 
```

```csharp
MatrixXD A = new MatrixXD("1 2 4; 3 5 7");
MatrixXD B = A.Transpose();

Console.WriteLine(A.ToString());

MatrixXD, 2 * 3:
    
    1 2 4 
    3 5 7 
    
Console.WriteLine(B.ToString());

MatrixXD, 3 * 2:

    1 3 
    2 5 
    4 7 
```


```csharp
// X = A * B^T
MatrixXD A = new MatrixXD("1 2 1; 2 5 2");
MatrixXD B = new MatrixXD("1 0 1; 1 1 0");
MatrixXD result = A.MultT(B);

Console.WriteLine(result.ToString());

MatrixXD, 2 * 2:  

    2 3 
    4 7 
```

```csharp
// X = A + A^T
MatrixXD A = new MatrixXD("2 2; 1 1");
MatrixXD result = A.PlusT();

Console.WriteLine(result.ToString());

MatrixXD, 2 * 2:

    4 3
    3 2

```

### Matrix-Vector Operations

```csharp
MatrixXD A = new MatrixXD("1 -2 ; 2 5 ; 4 -2");
VectorXD v = new VectorXD(new[] { 3.0, -7.0 });
VectorXD result = A.Mult(v);

Console.WriteLine(result.ToString());

VectorXD, 3:  

   17 -29 26

```
### EigenSolvers

Computes eigenvalues and eigenvectors of general matrices.
[EigenSolver](https://eigen.tuxfamily.org/dox/classEigen_1_1EigenSolver.html)

```csharp

MatrixXD A = new MatrixXD("0 1; -2 -3");
EigenSolverResult result = A.Eigen();
VectorXD eigenvalues = result.Eigenvalues.Real();
MatrixXD eigenvectors = result.Eigenvectors.Real();

Console.WriteLine(eigenvalues.ToString());

VectorXD, 2:

  -1 -2
  
Console.WriteLine(eigenvectors.ToString());

MatrixXD, 2 * 2:
    
 0.707 -0.447 
-0.707  0.894 
 
```

Computes eigenvalues and eigenvectors of selfadjoint matrices.
[SelfAdjointEigenSolver](https://eigen.tuxfamily.org/dox/classEigen_1_1SelfAdjointEigenSolver.html)
```csharp

MatrixXD A = new MatrixXD("2 1; 1 2");
SAEigenSolverResult result = A.SymmetricEigen();
VectorXD eigenvalues = result.Eigenvalues;
MatrixXD eigenvectors = result.Eigenvectors;

Console.WriteLine(eigenvalues.ToString());

VectorXD, 2:

  1 3
  
Console.WriteLine(eigenvectors.ToString());

MatrixXD, 2 * 2:

 -0.707 0.707 
  0.707 0.707 
 
```

## References
- https://eigen.tuxfamily.org/dox/group__QuickRefPage.html
- https://github.com/hughperkins/jeigen
- https://github.com/dotnet/machinelearning
