//
//  _MDPTweetSymbolModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPTweetSymbolModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPTweetSymbolModelAttributes {
	__unsafe_unretained NSString *indices;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *text;
} MDPTweetSymbolModelAttributes;

extern const struct MDPTweetSymbolModelRelationships {
	__unsafe_unretained NSString *tweetEntitiesIndices;
} MDPTweetSymbolModelRelationships;

@class MDPTweetEntitiesModel;

@interface _MDPTweetSymbolModel : NSManagedObject

@property (nonatomic, strong) NSData* indices;

//- (BOOL)validateIndices:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* text;

//- (BOOL)validateText:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *tweetEntitiesIndices;

- (NSMutableSet*)tweetEntitiesIndicesSet;

@end

@interface _MDPTweetSymbolModel (TweetEntitiesIndicesCoreDataGeneratedAccessors)
- (void)addTweetEntitiesIndices:(NSSet*)value_;
- (void)removeTweetEntitiesIndices:(NSSet*)value_;
- (void)addTweetEntitiesIndicesObject:(MDPTweetEntitiesModel*)value_;
- (void)removeTweetEntitiesIndicesObject:(MDPTweetEntitiesModel*)value_;
@end

@interface _MDPTweetSymbolModel (CoreDataGeneratedPrimitiveAccessors)

- (NSData*)primitiveIndices;
- (void)setPrimitiveIndices:(NSData*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveText;
- (void)setPrimitiveText:(NSString*)value;

- (NSMutableSet*)primitiveTweetEntitiesIndices;
- (void)setPrimitiveTweetEntitiesIndices:(NSMutableSet*)value;

@end
