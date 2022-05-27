USE [TodoList]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [varchar](50) NOT NULL,
	[Priority] [varchar](30) NOT NULL
	
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spAddTask]        
(        
    @TaskName VARCHAR(50),               
    @Priority VARCHAR(30)       
      
)        
as         
Begin         
    Insert into Tasks (TaskName,Priority)         
    Values (@TaskName,@Priority)         
End
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spDeleteTask]         
(          
   @Id int          
)          
as           
begin          
   Delete from Tasks where Id=@Id          
End
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spGetAllTask]      
as      
Begin      
    select *      
    from Tasks   
    order by Id 
End
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[spUpdateTask]          
(          
    @Id INTEGER ,        
    @TaskName VARCHAR(50),               
    @Priority VARCHAR(30)       
            
)          
as          
begin          
   Update Tasks           
   set TaskName=@TaskName,                 
   Priority=@Priority       
         
End
GO