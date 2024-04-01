Public Class Form1
    ' Declare variables at the class level
    Dim a() As Integer
    Dim num, i, j, temp As Integer
    Dim currentPass As Integer = 0
    Dim textBoxArrays As New List(Of TextBox())
    Dim messageTextBox As New TextBox() ' Declare messageTextBox at the class level

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Initialize the messageTextBox properties
        messageTextBox.Location = New Point(Me.Width - 900, 50) ' Adjusted position to the right
        messageTextBox.Size = New Size(200, 30)
        messageTextBox.Font = New Font(messageTextBox.Font.FontFamily, 12)
        messageTextBox.Text = ""
        messageTextBox.TextAlign = HorizontalAlignment.Center
        Me.Controls.Add(messageTextBox)
    End Sub

    Private Sub InputBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputBtn.Click
        ' Prompt user to enter the size of the array
        num = Val(InputBox("Enter the size of the array = ")) ' Dynamic Array
        ReDim a(num - 1) ' Declaration of the dynamic array

        ' Create an array of TextBox controls dynamically
        Dim textBoxArray(num - 1) As TextBox
        For i As Integer = 0 To num - 1
            textBoxArray(i) = New TextBox()
            textBoxArray(i).Location = New Point(20 + i * 40, 100)
            textBoxArray(i).Size = New Size(30, 30) ' Increase the size
            textBoxArray(i).Text = ""
            textBoxArray(i).Font = New Font(textBoxArray(i).Font.FontFamily, 12) ' Set the font size
            textBoxArray(i).TextAlign = HorizontalAlignment.Center ' Align text to the center
            Me.Controls.Add(textBoxArray(i))
        Next

        ' Input array elements
        For i As Integer = 0 To num - 1
            a(i) = Val(InputBox("Enter the elements of the array = "))
            textBoxArray(i).Text = a(i).ToString()
        Next

        ' Add the TextBox array to the list for later reference
        textBoxArrays.Add(textBoxArray)

        ' Display a message in the messageTextBox before starting sorting
        messageTextBox.Text = "Sorting started..."
    End Sub

    Private Sub InsertionBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertionBtn.Click
        If currentPass < num - 1 Then
            ' Perform one pass of the insertion sort
            temp = a(currentPass + 1)
            j = currentPass
            Do While j >= 0
                If a(j) > temp Then
                    a(j + 1) = a(j)
                Else
                    Exit Do
                End If
                j = j - 1
            Loop
            a(j + 1) = temp

            ' Create a new set of TextBox controls for the current pass
            Dim textBoxArray(num - 1) As TextBox
            For k As Integer = 0 To num - 1
                textBoxArray(k) = New TextBox()
                textBoxArray(k).Location = New Point(20 + k * 40, 150 + currentPass * 30)
                textBoxArray(k).Size = New Size(30, 30) ' Increase the size
                textBoxArray(k).Text = a(k).ToString()
                textBoxArray(k).Font = New Font(textBoxArray(k).Font.FontFamily, 12) ' Set the font size
                textBoxArray(k).TextAlign = HorizontalAlignment.Center ' Align text to the center
                Me.Controls.Add(textBoxArray(k))
            Next

            ' Add the TextBox array to the list for later reference
            textBoxArrays.Add(textBoxArray)

            currentPass += 1
        Else
            ' Display a message in the messageTextBox on completion of sorting
            messageTextBox.Text = "Sorting completed!"
        End If
    End Sub

    Private Sub ClearBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearBtn.Click
        ' Clear all TextBox controls created during sorting
        For Each textBoxArray In textBoxArrays
            For Each textBox In textBoxArray
                Me.Controls.Remove(textBox)
            Next
        Next
        textBoxArrays.Clear()
        currentPass = 0

        ' Clear the messageTextBox
        messageTextBox.Text = ""
    End Sub
End Class
