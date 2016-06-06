//
//  MDPResourcesHandler.h
//  MDPClient
//
//  Created by Ernesto Fernández Calles on 12/01/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>


#pragma mark - MDPResourcesHandlerDelegate
@class MDPLanguageResourcesHandler;
@protocol MDPLanguageResourcesHandlerDelegate <NSObject>
- (NSString *)resourcesFilePath:(MDPLanguageResourcesHandler *)sender;

@end


#pragma mark - Interface
@interface MDPLanguageResourcesHandler : NSObject

@property (nonatomic, weak) id <MDPLanguageResourcesHandlerDelegate> delegate;


#pragma mark Singleton
+ (MDPLanguageResourcesHandler *)sharedInstance;
+ (void)destroySharedInstance;


#pragma mark Resources update
- (void)fillLanguageDatabaseIfNecessary;
+ (void)deleteLanguageDatabase;
- (void)refreshResourcesFromAPIIfNecessaryWithCompletionBlock:(void (^)(BOOL finished))completionblock;
- (void)refreshResourcesWithDictionary:(NSDictionary *)resourcesInfo;


#pragma mark Resources configuration
- (BOOL)configureResourcesLanguage:(NSArray *)languagesCodes;
- (NSString *)configuredLanguage;
- (BOOL)isRTLLanguageWithCode:(NSString *)languageCode;


#pragma mark Localizated text
- (NSString *)localizedStringWithKey:(NSString *)keyString;

@end
