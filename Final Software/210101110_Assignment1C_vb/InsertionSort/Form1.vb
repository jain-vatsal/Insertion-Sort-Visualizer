Public Class Form1
    ' Declare variables at the class level
    Dim a() As Integer
    Dim num, i, j, temp As Integer
    Dim currentPass As Integer = 0
    Dim textBoxArrays As New List(Of TextBox())
    Dim WithEvents inputBtn As New Button() ' Declare inputBtn with WithEvents
    Dim WithEvents passBtn As New Button() ' Declare passBtn with WithEvents
    Dim WithEvents clearButton As New Button() ' Declare clearButton with WithEvents
    Dim WithEvents messageBox As New TextBox() ' Declare messageBox with WithEvents
    Dim WithEvents passTimer As New Timer() ' Timer to control the pass steps
    Dim WithEvents hideMessageBoxTimer As New Timer() ' Timer to hide message box after completion
    Dim WithEvents pausePlayBtn As New Button() ' Declare pausePlayBtn with WithEvents
    Dim isPaused As Boolean = False ' Flag to track whether the iterations are paused

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Add a label for the heading
        Dim headingLabel As New Label()
        headingLabel.Text = "Insertion Sort Visualizer"
        headingLabel.Font = New Font(headingLabel.Font.FontFamily, 16, FontStyle.Bold)
        headingLabel.ForeColor = Color.White
        headingLabel.BackColor = Color.DarkRed
        headingLabel.TextAlign = ContentAlignment.MiddleCenter
        headingLabel.Size = New Size(400, 30)
        headingLabel.Location = New Point((Me.Width - headingLabel.Width) \ 2, 30)
        Me.Controls.Add(headingLabel)

        ' Initialize the input button
        inputBtn.Text = "Input"
        inputBtn.Size = New Size(100, 60)
        inputBtn.Location = New Point(Me.Width - 200, headingLabel.Bottom + 20)
        inputBtn.BackColor = Color.Red
        inputBtn.ForeColor = Color.White
        inputBtn.Font = New Font(inputBtn.Font.FontFamily, 14, FontStyle.Bold)
        Me.Controls.Add(inputBtn)

        ' Initialize the pass button
        passBtn.Text = "Begin"
        passBtn.Size = New Size(100, 60)
        passBtn.Location = New Point(Me.Width - 200, inputBtn.Bottom + 10)
        passBtn.BackColor = Color.Blue
        passBtn.ForeColor = Color.White
        passBtn.Font = New Font(passBtn.Font.FontFamily, 14, FontStyle.Bold)
        passBtn.Visible = False ' Initialize as initially hidden
        Me.Controls.Add(passBtn)

        ' Initialize the clear button
        clearButton.Text = "Clear"
        clearButton.Size = New Size(100, 60)
        clearButton.Location = New Point(Me.Width - 200, passBtn.Bottom + 10)
        clearButton.BackColor = Color.Green
        clearButton.ForeColor = Color.White
        clearButton.Font = New Font(clearButton.Font.FontFamily, 14, FontStyle.Bold)
        Me.Controls.Add(clearButton)

        ' Initialize the messageBox properties
        messageBox.Size = New Size(240, 60)
        messageBox.Font = New Font(messageBox.Font.FontFamily, 12)
        messageBox.Text = ""
        messageBox.Multiline = True
        messageBox.TextAlign = HorizontalAlignment.Center
        messageBox.Anchor = AnchorStyles.None ' Center both horizontally and vertically
        messageBox.Location = New Point(20, (Me.Height - messageBox.Height) \ 2) ' Position in the left center
        messageBox.Visible = False ' Initialize as initially hidden
        Me.Controls.Add(messageBox)

        ' Initialize the passTimer properties
        passTimer.Interval = 2000 ' Set the timer interval to 2 seconds

        ' Initialize the hideMessageBoxTimer properties
        hideMessageBoxTimer.Interval = 3000 ' Set the timer interval to 3 seconds
        AddHandler hideMessageBoxTimer.Tick, AddressOf HideMessageBox

        ' Initialize the pausePlayBtn properties
        pausePlayBtn.Text = "Pause"
        pausePlayBtn.Size = New Size(100, 60)
        pausePlayBtn.Location = New Point(Me.Width - 200, clearButton.Bottom + 10)
        pausePlayBtn.BackColor = Color.Gray
        pausePlayBtn.ForeColor = Color.White
        pausePlayBtn.Font = New Font(pausePlayBtn.Font.FontFamily, 14, FontStyle.Bold)
        Me.Controls.Add(pausePlayBtn)
    End Sub

    Private Sub inputBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inputBtn.Click
        

        ' Prompt user to enter the size of the array with input validation
        Dim inputValid As Boolean = False

        Do
            Dim input As String = InputBox("Enter the size of the array (1-10) = ")

            If input Is Nothing Then
                Application.Exit()
                Return
            End If


            If Integer.TryParse(input, num) AndAlso num >= 1 AndAlso num <= 10 Then
                inputValid = True
            Else
                System.Windows.Forms.MessageBox.Show("Invalid input. Please enter a valid integer between 1 and 10.")
            End If
        Loop While Not inputValid

        ReDim a(num - 1) ' Declaration of the dynamic array

        ' Initialize the array with a light yellow background color
        Dim elementColor As Color = Color.LightYellow

        ' Create an array of TextBox controls dynamically
        Dim textBoxArray(num - 1) As TextBox

        inputValid = False

        For i As Integer = 0 To num - 1
            inputValid = False
            Do
                Dim input As String = InputBox("Enter the element of the array(1-99) = ")

                If input Is Nothing Then
                    Application.Exit()
                    Return
                End If

                If Integer.TryParse(input, a(i)) And a(i) >= 1 And a(i) <= 99 Then
                    inputValid = True
                Else
                    System.Windows.Forms.MessageBox.Show("Invalid input. Please enter a valid integer between 1 and 99.")
                End If
            Loop While inputValid = False

            textBoxArray(i) = New TextBox()
            textBoxArray(i).Location = New Point((Me.Width - (num * 40)) \ 2 + i * 40, 100)
            textBoxArray(i).Size = New Size(30, 30)
            textBoxArray(i).Text = a(i).ToString()
            textBoxArray(i).Font = New Font(textBoxArray(i).Font.FontFamily, 12, FontStyle.Bold)
            textBoxArray(i).TextAlign = HorizontalAlignment.Center
            textBoxArray(i).BackColor = elementColor
            Me.Controls.Add(textBoxArray(i))
        Next

        ' Add the TextBox array to the list for later reference
        textBoxArrays.Add(textBoxArray)

        ' Show the Pass button
        passBtn.Visible = True

        ' Display a message in the messageBox before starting sorting
        messageBox.Text = "Press 'Begin' to" & Environment.NewLine & "start insertion sort."
        messageBox.Visible = True
    End Sub

    Private Sub passBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles passBtn.Click
        If currentPass < num - 1 Then
            ' Set the messageBox text to indicate sorting is going on
            messageBox.Text = "Sorting going on..."

            ' Create a new set of TextBox controls for the current pass
            Dim textBoxArray(num - 1) As TextBox
            For k As Integer = 0 To num - 1
                textBoxArray(k) = New TextBox()
                textBoxArray(k).Location = New Point((Me.Width - (num * 40)) \ 2 + k * 40, 150 + currentPass * 30)
                textBoxArray(k).Size = New Size(30, 30)
                textBoxArray(k).Text = a(k).ToString()
                textBoxArray(k).Font = New Font(textBoxArray(k).Font.FontFamily, 12, FontStyle.Bold)
                textBoxArray(k).TextAlign = HorizontalAlignment.Center

                ' Set the background color based on the highlighting criteria
                If k <= currentPass Then
                    textBoxArray(k).BackColor = Color.LightGreen ' Green for elements up to currentPass
                ElseIf k = currentPass + 1 Then
                    textBoxArray(k).BackColor = Color.Red ' Red for the element at currentPass+1
                    textBoxArray(k).ForeColor = Color.White ' Change font color to white
                Else
                    textBoxArray(k).BackColor = Color.LightYellow ' Yellow for the remaining elements
                End If

                Me.Controls.Add(textBoxArray(k))
            Next

            ' Add the TextBox array to the list for later reference
            textBoxArrays.Add(textBoxArray)
            ' Perform one pass of the insertion sort
            Dim temp As Integer = a(currentPass + 1)
            Dim j As Integer = currentPass

            Do While j >= 0 AndAlso a(j) > temp
                a(j + 1) = a(j)
                j = j - 1
            Loop

            a(j + 1) = temp

            currentPass += 1

            ' Start the passTimer to control the iterations
            passTimer.Start()
        Else
            ' Set the messageBox text to indicate sorting is going on
            messageBox.Text = "Sorting going on..."

            ' Create a new set of TextBox controls for the final pass
            Dim textBoxArray(num - 1) As TextBox
            For k As Integer = 0 To num - 1
                textBoxArray(k) = New TextBox()
                textBoxArray(k).Location = New Point((Me.Width - (num * 40)) \ 2 + k * 40, 150 + currentPass * 30)
                textBoxArray(k).Size = New Size(30, 30)
                textBoxArray(k).Text = a(k).ToString()
                textBoxArray(k).Font = New Font(textBoxArray(k).Font.FontFamily, 12, FontStyle.Bold)
                textBoxArray(k).TextAlign = HorizontalAlignment.Center

                ' Set the background color based on the highlighting criteria
                If k <= currentPass Then
                    textBoxArray(k).BackColor = Color.LightGreen ' Green for elements up to currentPass
                ElseIf k = currentPass + 1 Then
                    textBoxArray(k).BackColor = Color.LightGreen ' Red for the element at currentPass+1
                    textBoxArray(k).ForeColor = Color.White ' Change font color to white
                Else
                    textBoxArray(k).BackColor = Color.LightGreen ' Yellow for the remaining elements
                End If

                Me.Controls.Add(textBoxArray(k))
            Next

            ' Add the TextBox array to the list for later reference
            textBoxArrays.Add(textBoxArray)

            ' Display a message in the messageBox on completion of sorting
            messageBox.Text = "Sorting completed!"
            ' Hide the Pass button
            passBtn.Visible = False
            ' Show the messageBox
            messageBox.Visible = True
            ' Start the hideMessageBoxTimer to hide the message box after 3 seconds
            hideMessageBoxTimer.Start()
        End If
    End Sub

    Private Sub passTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles passTimer.Tick
        ' Stop the timer if paused
        If isPaused Then
            Return
        End If

        ' Stop the timer
        passTimer.Stop()

        ' Continue to the next iteration after the timer interval
        passBtn.PerformClick()
    End Sub

    Private Sub hideMessageBoxTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles hideMessageBoxTimer.Tick
        ' Stop the timer
        hideMessageBoxTimer.Stop()

        ' Hide the messageBox
        messageBox.Visible = False
    End Sub

    Private Sub pausePlayBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pausePlayBtn.Click
        ' Toggle the flag to pause or continue the iterations
        isPaused = Not isPaused

        ' Update the button text based on the flag
        If isPaused Then
            pausePlayBtn.Text = "Play"
            ' Stop the passTimer if paused
            passTimer.Stop()
        Else
            pausePlayBtn.Text = "Pause"
            ' Continue the passTimer if resumed
            passTimer.Start()
        End If
    End Sub

    Private Sub clearButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearButton.Click
        ' Clear all TextBox controls created during sorting
        RemoveTextBoxControls()
        textBoxArrays.Clear()
        currentPass = 0

        ' Hide the Pass button
        passBtn.Visible = False
        ' Hide the messageBox
        messageBox.Visible = False
    End Sub

    Private Sub RemoveTextBoxControls()
        ' Remove all TextBox controls
        For Each textBoxArray In textBoxArrays
            For Each textBox In textBoxArray
                Me.Controls.Remove(textBox)
            Next
        Next
    End Sub

    Private Sub HideMessageBox(ByVal sender As Object, ByVal e As EventArgs)
        ' Hide the messageBox
        messageBox.Visible = False

        ' Stop the timer
        hideMessageBoxTimer.Stop()
    End Sub
End Class