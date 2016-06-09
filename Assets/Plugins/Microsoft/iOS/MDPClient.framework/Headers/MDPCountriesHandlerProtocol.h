//
//  MDPCountriesHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 16/8/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPCountriesHandlerProtocol_h
#define MDPClient_MDPCountriesHandlerProtocol_h


#pragma mark  - Response
typedef void (^MDPCountriesHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPCountriesHandlerProtocol
@protocol MDPCountriesHandlerProtocol <NSObject>

/*
 Gets a list of all countries.  Internal Method, no available for users.
 */
+ (void)getCountriesByLanguageWithLanguage:(NSString *)language completionBlock:(MDPCountriesHandlerResponseBlock)completionBlock;

/*
 Gets a list of states of a country
 */
+ (void)getCountryStatesWithLanguage:(NSString *)language
                         countryCode:(NSString *)countryCode
                     completionBlock:(MDPCountriesHandlerResponseBlock)completionBlock;

/*
 Listens to MDPCountryModel objects. Return the elements order for countries
 */
+ (NSMutableDictionary *)countriesWithLanguage:(NSString *)language;

+ (NSMutableDictionary *)countryWithLanguage:(NSString *)language countryCode:(NSString *)countryCode;

@end


#endif
