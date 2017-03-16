//
//  MDPLanguagesHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 14/8/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPLanguagesHandlerProtocol_h
#define MDPClient_MDPLanguagesHandlerProtocol_h

#import "MDPLanguageModel.h"

#pragma mark  - Response
typedef void (^MDPLanguagesHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPLanguagesHandlerProtocol
@protocol MDPLanguagesHandlerProtocol <NSObject>


/**
 Retrieve languages supported by platform giving a specific country code.
 */
+ (void)getLanguagesWithLanguage:(NSString *)language completionBlock:(MDPLanguagesHandlerResponseBlock)completionBlock;


/*
 Retrieve languages of the database
 */
+ (NSMutableDictionary *)languagesWithLanguageLocale:(NSString *)languageLocale;

+ (NSMutableDictionary *)languageWithLanguageCode:(NSString *)languageCode
                                   languageLocale:(NSString *)languageLocale
                                         delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end

#endif
