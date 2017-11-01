/** 
 * Copyright 2017 Telerik AD                                                                                                                                                                            
 *                                                                                                                                                                                                      
 * Licensed under the Apache License, Version 2.0 (the "License");                                                                                                                                      
 * you may not use this file except in compliance with the License.                                                                                                                                     
 * You may obtain a copy of the License at                                                                                                                                                              
 *                                                                                                                                                                                                      
 *     http://www.apache.org/licenses/LICENSE-2.0                                                                                                                                                       
 *                                                                                                                                                                                                      
 * Unless required by applicable law or agreed to in writing, software                                                                                                                                  
 * distributed under the License is distributed on an "AS IS" BASIS,                                                                                                                                    
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.                                                                                                                             
 * See the License for the specific language governing permissions and                                                                                                                                  
 * limitations under the License.                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       

*/

(function(f){
    if (typeof define === 'function' && define.amd) {
        define(["kendo.core"], f);
    } else {
        f();
    }
}(function(){
(function( window, undefined ) {
    kendo.cultures["byn-ER"] = {
        name: "byn-ER",
        numberFormat: {
            pattern: ["-n"],
            decimals: 2,
            ",": ",",
            ".": ".",
            groupSize: [3],
            percent: {
                pattern: ["-n%","n%"],
                decimals: 2,
                ",": ",",
                ".": ".",
                groupSize: [3],
                symbol: "%"
            },
            currency: {
                name: "Eritrean Nakfa",
                abbr: "ERN",
                pattern: ["-$n","$n"],
                decimals: 2,
                ",": ",",
                ".": ".",
                groupSize: [3],
                symbol: "Nfk"
            }
        },
        calendars: {
            standard: {
                days: {
                    names: ["ሰንበር ቅዳዅ","ሰኑ","ሰሊጝ","ለጓ ወሪ ለብዋ","ኣምድ","ኣርብ","ሰንበር ሽጓዅ"],
                    namesAbbr: ["ሰ/ቅ","ሰኑ","ሰሊጝ","ለጓ","ኣምድ","ኣርብ","ሰ/ሽ"],
                    namesShort: ["ሰ/ቅ","ሰኑ","ሰሊጝ","ለጓ","ኣምድ","ኣርብ","ሰ/ሽ"]
                },
                months: {
                    names: ["ልደትሪ","ካብኽብቲ","ክብላ","ፋጅኺሪ","ክቢቅሪ","ምኪኤል ትጟኒሪ","ኰርኩ","ማርያም ትሪ","ያኸኒ መሳቅለሪ","መተሉ","ምኪኤል መሽወሪ","ተሕሳስሪ"],
                    namesAbbr: ["ልደት","ካብኽ","ክብላ","ፋጅኺ","ክቢቅ","ም/ት","ኰር","ማርያ","ያኸኒ","መተሉ","ም/ም","ተሕሳ"]
                },
                AM: ["AM","am","AM"],
                PM: ["PM","pm","PM"],
                patterns: {
                    d: "dd/MM/yyyy",
                    D: "dddd፡ dd MMMM ግርጋ yyyy gg",
                    F: "dddd፡ dd MMMM ግርጋ yyyy gg h:mm:ss tt",
                    g: "dd/MM/yyyy h:mm tt",
                    G: "dd/MM/yyyy h:mm:ss tt",
                    m: "MMMM d",
                    M: "MMMM d",
                    s: "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                    t: "h:mm tt",
                    T: "h:mm:ss tt",
                    u: "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
                    y: "yyyy MMMM",
                    Y: "yyyy MMMM"
                },
                "/": "/",
                ":": ":",
                firstDay: 1
            }
        }
    }
})(this);
}));