//
//  _MDPTweetEntitiesModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPTweetEntitiesModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPTweetEntitiesModelAttributes {
	__unsafe_unretained NSString *lastUpdateAt;
} MDPTweetEntitiesModelAttributes;

extern const struct MDPTweetEntitiesModelRelationships {
	__unsafe_unretained NSString *hashtags;
	__unsafe_unretained NSString *media;
	__unsafe_unretained NSString *symbols;
	__unsafe_unretained NSString *tweetEntities;
	__unsafe_unretained NSString *urls;
	__unsafe_unretained NSString *userMentions;
} MDPTweetEntitiesModelRelationships;

@class MDPTweetHashtagModel;
@class MDPTweetMediaModel;
@class MDPTweetSymbolModel;
@class MDPTweetModel;
@class MDPTweetUrlModel;
@class MDPTweetUserMentionsModel;

@interface _MDPTweetEntitiesModel : NSManagedObject

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *hashtags;

- (NSMutableSet*)hashtagsSet;

@property (nonatomic, strong) NSOrderedSet *media;

- (NSMutableOrderedSet*)mediaSet;

@property (nonatomic, strong) NSSet *symbols;

- (NSMutableSet*)symbolsSet;

@property (nonatomic, strong) MDPTweetModel *tweetEntities;

//- (BOOL)validateTweetEntities:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *urls;

- (NSMutableSet*)urlsSet;

@property (nonatomic, strong) NSSet *userMentions;

- (NSMutableSet*)userMentionsSet;

@end

@interface _MDPTweetEntitiesModel (HashtagsCoreDataGeneratedAccessors)
- (void)addHashtags:(NSSet*)value_;
- (void)removeHashtags:(NSSet*)value_;
- (void)addHashtagsObject:(MDPTweetHashtagModel*)value_;
- (void)removeHashtagsObject:(MDPTweetHashtagModel*)value_;
@end

@interface _MDPTweetEntitiesModel (MediaCoreDataGeneratedAccessors)
- (void)addMedia:(NSOrderedSet*)value_;
- (void)removeMedia:(NSOrderedSet*)value_;
- (void)addMediaObject:(MDPTweetMediaModel*)value_;
- (void)removeMediaObject:(MDPTweetMediaModel*)value_;
@end

@interface _MDPTweetEntitiesModel (SymbolsCoreDataGeneratedAccessors)
- (void)addSymbols:(NSSet*)value_;
- (void)removeSymbols:(NSSet*)value_;
- (void)addSymbolsObject:(MDPTweetSymbolModel*)value_;
- (void)removeSymbolsObject:(MDPTweetSymbolModel*)value_;
@end

@interface _MDPTweetEntitiesModel (UrlsCoreDataGeneratedAccessors)
- (void)addUrls:(NSSet*)value_;
- (void)removeUrls:(NSSet*)value_;
- (void)addUrlsObject:(MDPTweetUrlModel*)value_;
- (void)removeUrlsObject:(MDPTweetUrlModel*)value_;
@end

@interface _MDPTweetEntitiesModel (UserMentionsCoreDataGeneratedAccessors)
- (void)addUserMentions:(NSSet*)value_;
- (void)removeUserMentions:(NSSet*)value_;
- (void)addUserMentionsObject:(MDPTweetUserMentionsModel*)value_;
- (void)removeUserMentionsObject:(MDPTweetUserMentionsModel*)value_;
@end

@interface _MDPTweetEntitiesModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSMutableSet*)primitiveHashtags;
- (void)setPrimitiveHashtags:(NSMutableSet*)value;

- (NSMutableOrderedSet*)primitiveMedia;
- (void)setPrimitiveMedia:(NSMutableOrderedSet*)value;

- (NSMutableSet*)primitiveSymbols;
- (void)setPrimitiveSymbols:(NSMutableSet*)value;

- (MDPTweetModel*)primitiveTweetEntities;
- (void)setPrimitiveTweetEntities:(MDPTweetModel*)value;

- (NSMutableSet*)primitiveUrls;
- (void)setPrimitiveUrls:(NSMutableSet*)value;

- (NSMutableSet*)primitiveUserMentions;
- (void)setPrimitiveUserMentions:(NSMutableSet*)value;

@end
