﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfMultiColumnDropDownControlDemo
{
    class MovieListRepository : ObservableCollection<GrossingMoviesList>
    {
        public MovieListRepository()
        {
            this.Add(new GrossingMoviesList(1, "Iron Man 3", "Robert Downney Jr", "Shane Black", "Sci-Fi", "PG-13"));
            this.Add(new GrossingMoviesList(2, "The Croods", "Nicolas Cage", "Kirk De Micco, Chris Sanders", "Animation", "PG"));
            this.Add(new GrossingMoviesList(3, "Oz the Great and Powerful", "James Franco", "Sam Raimi", "Adventure", "PG"));
            this.Add(new GrossingMoviesList(4, "G.I Joe Retaliation", "Dwayne Johnson", "Jon M.Chu", "Action", "PG-13"));
            this.Add(new GrossingMoviesList(5, "A Good Day to Die Hard", "Bruce Wills", "John Moore", "Crime", "R"));
            this.Add(new GrossingMoviesList(6, "Hansel and Gretel Witch Hunters", "Jermy Renner", "Tommy Wirkola", "Fantasy", "R"));
            this.Add(new GrossingMoviesList(7, "Oblivion", "Tom Cruise", "Joseph Kosinski", "Mystery", "PG-13"));
            this.Add(new GrossingMoviesList(8, "Journey to the West Conquering the Demons", "Qi Shu", "Stephen Chow", "Fantasy", "R"));
            this.Add(new GrossingMoviesList(9, "Jack the Giant Slayer", "Nicholas Hoult", "Bryan Singer", "Fantasy", "PG-13"));
            this.Add(new GrossingMoviesList(10, "Identity Thief", "Jason Batman", "Seth Gordon", "Crime", "R"));
        }
    }
}
