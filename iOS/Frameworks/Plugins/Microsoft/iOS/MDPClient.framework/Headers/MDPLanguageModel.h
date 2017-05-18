//
//  MDPLanguageModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPLanguageModel.h"


#pragma mark - Interface
@interface MDPLanguageModel : _MDPLanguageModel

+ (NSArray *)languagesWithManagedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsLanguageWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSMutableDictionary *)languagesWithLanguageLocale:(NSString *)languageLocale managedObjectContext:(NSManagedObjectContext *)context;

+ (NSMutableDictionary *)languageWithLanguageCode:(NSString *)languageCode
                                   languageLocale:(NSString *)languageLocale
                             managedObjectContext:(NSManagedObjectContext *)context
                                         delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
