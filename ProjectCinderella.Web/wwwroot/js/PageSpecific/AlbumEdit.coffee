#Usings
Namespace "Views.Album"

#Initialization
Views.Album.Layout = ->
		
#Implementation
class Views.Album.Edit 
	init: ->
		$("#ddlAlbumType").on "change", ->
			if $("#ddlAlbumType :selected").text() is "Vinyl" then $("#vinylInfo").removeClass("hidden") 
			else $("#vinylInfo").addClass("hidden")
$ -> 
	_edit = new Views.Album.Edit
	
	_edit.init()