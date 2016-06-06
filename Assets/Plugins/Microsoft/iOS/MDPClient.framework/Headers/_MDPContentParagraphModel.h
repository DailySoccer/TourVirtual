//
//  _MDPContentParagraphModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPContentParagraphModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPContentParagraphModelAttributes {
	__unsafe_unretained NSString *body;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *title;
} MDPContentParagraphModelAttributes;

extern const struct MDPContentParagraphModelRelationships {
	__unsafe_unretained NSString *contentBody;
} MDPContentParagraphModelRelationships;

@class MDPContentModel;

@interface _MDPContentParagraphModel : NSManagedObject

@property (nonatomic, strong) NSString* body;

//- (BOOL)validateBody:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* title;

//- (BOOL)validateTitle:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *contentBody;

- (NSMutableSet*)contentBodySet;

@end

@interface _MDPContentParagraphModel (ContentBodyCoreDataGeneratedAccessors)
- (void)addContentBody:(NSSet*)value_;
- (void)removeContentBody:(NSSet*)value_;
- (void)addContentBodyObject:(MDPContentModel*)value_;
- (void)removeContentBodyObject:(MDPContentModel*)value_;
@end

@interface _MDPContentParagraphModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveBody;
- (void)setPrimitiveBody:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveTitle;
- (void)setPrimitiveTitle:(NSString*)value;

- (NSMutableSet*)primitiveContentBody;
- (void)setPrimitiveContentBody:(NSMutableSet*)value;

@end
