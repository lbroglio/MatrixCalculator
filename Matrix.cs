using System;
using System.IO; 
using System.Collections.Generic;


private class MatrixSize{
    public readonly int numRows;
    public readonly int numCols;

    public MatrixSize(int numRows ,int numCols){
        this.numRows = numRows;
        this.numCols = numCols;
       

    }

    public override String ToString(){
        return string.Format("{0}x{1}",numRows,numCols);
    }

}



public class Matrix<T>{
    MatrixSize size;
    //This needs  to be changed to accomondate different type of matrices - might need its own data type
    T[,] contents;
    T determinant;

    private MatrixSize findSize(String filepath){
        StreamReader checkFrom = File.OpenText(filepath);
       
        int rowNum =0;
        int colNum =0;
        string lineFrom = "";

        while(checkFrom.EndOfStream == false){
         
                lineFrom = checkFrom.ReadLine();
                rowNum++;
        }
        
        checkFrom.Close();

       
        StringReader fromLine = new StringReader(lineFrom);
        
        while(fromLine.Peek() != -1){
                char check = (char) fromLine.Read();
                if(check != ' '){
                    colNum++;
                }
                
                
        }

    fromLine.Close();
    return new MatrixSize(rowNum,colNum);
    }

    private void getMatrixFromFile(String filepath){
        StreamReader getFrom = File.OpenText(filepath);
        for(int i=0; i<size.numRows; i++){
            string currLine = getFrom.ReadLine();
            StringReader lineRead = new StringReader(currLine);
            for(int k=0; k<size.numCols; k++){
                char asChar = (char) lineRead.Read();
                if(asChar == ' ' ){
                    k-=1;
                }
                else{
                T toAdd = (T) Convert.ChangeType(asChar-'0',typeof(T));
                contents[i,k] = toAdd;
                }
           
        }
         lineRead.Close();
        }
        getFrom.Close();
    }

    public Matrix(String filepath){
        size = findSize(filepath);
        contents = new T[size.numRows,size.numCols];
        getMatrixFromFile(filepath);

    }
    public Matrix(T[,] getMatrix){
        size = new MatrixSize (getMatrix.length,getMatrix.GetLength(0));
        contents = getMatrix.Clone();
    }
    public Matrix(int numRows,int numCols){
        size = new MatrixSize(numRows,numCols);
        contents = new T[size.numRows,size.numCols];
    }


    public override String ToString(){
        string toReturn = "";
        
        for(int i=0; i<size.numRows;i++){
            for(int k=0; k<size.numCols;k++){
                toReturn+=contents[i,k];
                if(k!=contents.GetLength(1)-1){
                    toReturn += " ";
                }

        }
        if(i != size.numRows-1){
            toReturn += "\n";
        } 
        }
        return toReturn;
    }

}